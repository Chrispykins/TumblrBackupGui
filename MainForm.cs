using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace TumblrBackupGui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            OutputFolderDialog = new FolderBrowserDialog();
        }

        public FolderBrowserDialog OutputFolderDialog;
        public List<TextBox> BlogTextBoxes = new List<TextBox>();
        public List<Button> AddButtons = new List<Button>();
        public List<Button> RemoveButtons = new List<Button>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            groupBox1.Controls.Add(BlogNamePanel);

            //load fonts
            PrivateFontCollection fontCollection = new PrivateFontCollection();

            try
            {
                fontCollection.AddFontFile(@"Resources\GenBasB.ttf");
                fontCollection.AddFontFile(@"Resources\GenBasR.ttf");

                //set fonts
                DownloadButton.Font = new Font((FontFamily)fontCollection.Families.GetValue(0), 14.0f);
                label1.Font = new Font((FontFamily)fontCollection.Families.GetValue(0), 12.0f);
                groupBox1.Font = new Font((FontFamily)fontCollection.Families.GetValue(0), 12.0f);
            }
            catch
            {
                //font file has been lost, we'll just use the default fonts.
            }

            //output folder setup
            OutputFolderText.Text = AppDomain.CurrentDomain.BaseDirectory;

            OutputFolderText.KeyDown += MainForm_KeyDown;
            OutputFolderButton.MouseDown += OutputFolderButton_Click;
            DownloadButton.MouseDown += DownloadButton_Click;

            for (int i = 0; i < 8; i++)
            {
                AddBlogBox(i);
            }

            AdjustBlogBoxPositions();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitiateDownload();
            }
        }

        public void AddBlogBox(int index)
        {
            TextBox newBox = new TextBox();
            Button newRemoveButton = new Button();
            Button newAddButton = new Button();

            newBox.KeyDown += MainForm_KeyDown;
            newRemoveButton.MouseDown += RemoveButtonClicked;
            newAddButton.MouseDown += AddButtonClicked;

            BlogTextBoxes.Insert(index, newBox);
            RemoveButtons.Insert(index, newRemoveButton);
            AddButtons.Insert(index, newAddButton);

            newRemoveButton.BackColor = Color.White;
            newRemoveButton.BackgroundImage = Properties.Resources.minus;
            newRemoveButton.BackgroundImageLayout = ImageLayout.Stretch;

            newAddButton.BackColor = Color.White;
            newAddButton.BackgroundImage = Properties.Resources.plus;
            newAddButton.BackgroundImageLayout = ImageLayout.Stretch;

            BlogNamePanel.Controls.Add(newBox);
            BlogNamePanel.Controls.Add(newRemoveButton);
            BlogNamePanel.Controls.Add(newAddButton);
        }

        public void RemoveBlogBox(int index)
        {
            if (index >= 0)
            {
                BlogTextBoxes[index].Text = "";

                //Don't allow user to remove last text entry
                if (BlogTextBoxes.Count > 1)
                {
                    BlogTextBoxes[index].Dispose();
                    AddButtons[index].Dispose();
                    RemoveButtons[index].Dispose();

                    BlogTextBoxes.RemoveAt(index);
                    AddButtons.RemoveAt(index);
                    RemoveButtons.RemoveAt(index);
                }
            }
        }

        public void AdjustBlogBoxPositions()
        {
            for (int i = 0; i < BlogTextBoxes.Count; i++)
            {
                TextBox box = BlogTextBoxes[i];
                Button add = AddButtons[i];
                Button minus = RemoveButtons[i];

                int YPosition = i * (box.Height + 5) + BlogNamePanel.AutoScrollPosition.Y;
                int height = box.Height;

                box.Location = new Point(0, YPosition);
                box.Size = new Size(BlogNamePanel.Size.Width - 115, height);
                box.TabIndex = BlogNamePanel.TabIndex + 1 + i;

                minus.Location = new Point(box.Size.Width + 15, YPosition);
                minus.Size = new Size(height, height);
                minus.TabIndex = BlogNamePanel.TabIndex + 1 + BlogTextBoxes.Count + (i * 2);

                add.Location = new Point(minus.Location.X + minus.Width + 5, YPosition);
                add.Size = new Size(height, height);
                add.TabIndex = BlogNamePanel.TabIndex + 1 + BlogTextBoxes.Count  + (i * 2) + 1;
            }
        }

        private void OutputFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = OutputFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                OutputFolderText.Text = OutputFolderDialog.SelectedPath;
            }
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            int index = AddButtons.IndexOf((Button)sender);

            AddBlogBox(index + 1);
            AdjustBlogBoxPositions();
        }

        private void RemoveButtonClicked(object sender, EventArgs e)
        {
            int index = RemoveButtons.IndexOf((Button)sender);

            RemoveBlogBox(index);
            AdjustBlogBoxPositions();

        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            InitiateDownload();
        }

        public void InitiateDownload()
        {
            //clear previous errors away
            ErrorText.Text = "";

            string outputPath = OutputFolderText.Text;
            string names = "";

            for (int i = 0; i < BlogTextBoxes.Count; i++)
            {
                String blogName = BlogTextBoxes[i].Text;
                bool validName = true;

                blogName.Trim();

                //valid conditions for blog name
                validName &= blogName.IndexOfAny(new char[] { ' ', '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '=', '+', '[', '{', ']', '}', '\\', '|', ';', ':', '\'', '\"', ',', '<', '.', '>', '/', '?' }) == -1;
                validName &= blogName.Length > 0;

                if (validName)
                {
                    names += blogName + " ";
                    BlogTextBoxes[i].Text = "";
                }
                else if (blogName.Length > 0)
                {
                    ErrorText.Text += "\"" + @blogName + "\" is not a valid blog name!\n";
                }
            }

            //ensure valid output path
            if (outputPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                ErrorText.Text += "Invalid Output Path!\n";
                return;
            }
            else if (outputPath.Length != 0 && !Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            //if there were any valid blog-names at all
            if (names.Length > 0)
            {
                Process process = new Process
                {
                    StartInfo = {
                        WorkingDirectory = @outputPath,
                        FileName = AppDomain.CurrentDomain.BaseDirectory + "tumblr_backup/tumblr_backup.exe ",
                        Arguments = @names
                    }
                };

                try
                {
                    process.Start();
                }
                catch (Exception err)
                {
                    ErrorText.Text += "Couldn't run tumblr_backup.exe!\nAre all files and folders extracted? Is the tumblr_backup folder in the same folder as this application?\n";
                    process.Dispose();
                }

                process.Dispose();
            }
        }
    }
}
