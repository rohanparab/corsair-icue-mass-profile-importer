using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;

namespace CorsairProfileImporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tblack.BackColor = Color.FromArgb(125, Color.Black);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closex_MouseEnter(object sender, EventArgs e)
        {
            closex.ForeColor = Color.Red;
        }

        private void closex_MouseLeave(object sender, EventArgs e)
        {
            closex.ForeColor = Color.White;
        }

        private void closex_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                int doit = 1;
                String mainfile, fid = "";
                String userName = Environment.UserName;
                String destination = "C:\\Users\\"+ userName +"\\AppData\\Roaming\\Corsair\\CUE\\profiles\\";
                String dir = folderBrowserDialog1.SelectedPath;
                dirval.Text = dir;
                string[] filePaths = Directory.GetFiles(@dir, "*.cueprofile");

                for (int i = 0; i < filePaths.Length; i++)
                {
                    doit = 1;
                    mainfile = filePaths[i];
                    Console.WriteLine(filePaths[i]);

                    XmlTextReader xtr = new XmlTextReader(mainfile);

                    while (xtr.Read())
                    {
                        if (xtr.Name == "id" && doit == 1)
                        {
                            fid = xtr.ReadElementContentAsString();
                            //Console.WriteLine(fid);
                            doit = 0;

                        }
                    }

                    string text = File.ReadAllText(mainfile);
                    text = text.Replace(@"	<value0>
		<cereal_class_version>300</cereal_class_version>", "");
                    text = text.Replace(@"	</value0>
</cereal>", "");
                    //text = text.Replace(@"	</value0>", "");
                    text = text + "</<cereal>";
                    //System.IO.File.Copy(mainfile, destination+fid+".cueprofile", true);
                    File.WriteAllText(destination + fid + ".cueprofiledata", text);
                    count++;
                }
            }
            detected.Text = count + " iCue Profiles Detected and Patched..!";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/encryptedguy");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/encryptedguy");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/encryptedguy");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/encryptedguy");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.fb.me/encryptedguy");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com/encryptedguy");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.rohanparab.com/CorsairIcue");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
