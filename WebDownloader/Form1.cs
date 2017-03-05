using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebDownloader.Classes;

namespace WebDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_startDownload_Click(object sender, EventArgs e)
        {
            string linkAddress = tb_addressToDownload.Text;
            string saveToFolder = tb_saveTo.Text;

            if (string.IsNullOrEmpty(saveToFolder))
            {
                return;
            }

            if (!Directory.Exists(saveToFolder))
            {
                Directory.CreateDirectory(saveToFolder);
                if (!Directory.Exists(saveToFolder))
                {
                    //--Illegal folder:
                    MessageBox.Show("Ah~~~~Illegal directory.");
                    return;
                }
            }

            Downloader.StartDownloader(linkAddress,saveToFolder);
        }

        private void btn_broswer_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            DialogResult result = browserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                tb_saveTo.Text = browserDialog.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            MyDebug.Debug.SetCallbackLogStr((strMsg) =>
                {
                    lb_logView.Items.Add(strMsg);
                });
        }
    }
}
