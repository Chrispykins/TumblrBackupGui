﻿using System;
using System.Windows.Forms;



namespace TumblrBackupGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error!");
            }
            
        }
    }
}
