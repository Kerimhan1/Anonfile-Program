using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Anonfile.com
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region code
        private static void Upload(string file)
        {
            try
            {
                string Uploading = Encoding.UTF8.GetString(new WebClient().UploadFile("https://anonfiles.com/api/upload", file));
                JObject parsed = JObject.Parse(Uploading);
                string url = parsed["data"]["file"]["url"]["full"].ToString();
                Process.Start(url);
            } catch { MessageBox.Show("Something went wrong"); }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Upload(textBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog run = new OpenFileDialog();
            DialogResult result = run.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = run.FileName;
                textBox1.Text = file;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is really simple to use just input the file you wanna upload and then just click on the upload button it will upload for you and when its done it will auto show the page");
        }
        #endregion
    }
}
