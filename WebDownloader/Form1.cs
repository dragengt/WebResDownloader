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
    }
}
