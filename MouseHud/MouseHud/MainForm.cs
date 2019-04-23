using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHud
{
    static class UsrInf
    {
        public static string UserInformationTxt;
    }

    public partial class MainForm : Form
    {
        int FrameWidth = 0;
        int FrameHeight = 0;
        String SavePath = "";
        String BasicName = "";
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        Timer timer1 = new Timer();

        public MainForm()
        {
            //Load saved settings
            FrameHeight = Properties.Settings.Default.FrameHeight;
            FrameWidth = Properties.Settings.Default.FrameWidth;
            SavePath = Properties.Settings.Default.SavePath;
            BasicName = Properties.Settings.Default.BasicFileName;

            if (SavePath == "")
            {
                SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            //No Border for Frame
            this.FormBorderStyle = FormBorderStyle.None;

            //Transparent Background
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

            InitializeComponent();

            //Add CustomFrame with green border
            var FrmBorder = new CustomPanel
            {
                Name = "FrmBorder",
                Location = new Point(0, 0),
                Size = new Size(FrameHeight, FrameWidth)
            };
            this.Controls.Add(FrmBorder);

            //Add Label Size
            Label lblSize = new Label
            {
                Name = "lbl_Size",
                Size = new Size(100, 12),
                Location = new Point(FrameWidth - 50, FrameHeight),
                ForeColor = Color.LightGreen,
                Text = FrameHeight.ToString() + " x " + FrameWidth.ToString()
            };
            this.Controls.Add(lblSize);

            //Add Label Mouseposition
            String Mx = Cursor.Position.X.ToString();
            String My = Cursor.Position.Y.ToString();

            Label lblMousePos = new Label()
            {
                Name = "lbl_MousePos",
                Size = new Size(100, 12),
                Location = new Point(0, FrameHeight),
                ForeColor = Color.LightGreen,
                Text = "X: " + Mx + " Y: " + My
            };
            this.Controls.Add(lblMousePos);

            //Add Label User Information
            int WidthInfo = 100;
            int PosX = (FrameWidth / 2) - (WidthInfo / 2);
            int PosY = (FrameHeight / 2) - 6;

            Label lblUserInfo = new Label()
            {
                Name = "lbl_UserInfo",
                Size = new Size(WidthInfo, 12),
                Location = new Point(PosX, PosY),
                ForeColor = Color.LightGreen,
                Text = ""
            };
            this.Controls.Add(lblUserInfo);
            lblUserInfo.BringToFront();

            //Create Timer for following Mouse Movement
            timer1.Tick += new EventHandler(TimerFollowMouse_Tick);
            timer1.Interval = (10);
            timer1.Enabled = true;
            timer1.Start();
        }

        Timer timerMsg = new Timer();

        public void UserInformation(int Interval = 0)
        {
            
            if (Interval > 0)
            {
                timerMsg.Tick += new EventHandler(TimerMsg_Tick);
                timerMsg.Interval = Interval;
                timerMsg.Enabled = true;
                timerMsg.Start();

                return;
            }

            var lblUserInfo = Controls.Find("lbl_UserInfo", true).FirstOrDefault();
            lblUserInfo.Text = UsrInf.UserInformationTxt;

        }

        private void TimerMsg_Tick(object sender, EventArgs e)
        {
            var lblUserInfo = Controls.Find("lbl_UserInfo", true).FirstOrDefault();
            lblUserInfo.Text = UsrInf.UserInformationTxt;
        }

        private void TimerFollowMouse_Tick(object sender, EventArgs e)
        {
            FollowMousePosition();
        }

        private void FollowMousePosition()
        {
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;

            X = X - FrameWidth / 2;
            Y = Y - FrameHeight / 2;
            this.Location = new Point(X, Y);

            var lblMouse = Controls.Find("lbl_MousePos", true).FirstOrDefault();
            lblMouse.Text = "X: " + X.ToString() + " Y: " + Y.ToString() ;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs ex)
        {
            string xo = ex.KeyChar.ToString();
            //Close with control + s
            if (xo == "\u0003") //strg + c || Close App
            {
                this.Close();
            }
            else if (xo == "\u0013") //Strg + s || Add Something to change size
            {
                UfSettings FrmSet = new UfSettings();
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;

                X = X - FrameWidth / 2;
                Y = Y - FrameHeight / 2;

                FrmSet.Show();
                FrmSet.Location = new Point(X, Y);

                var FrmBorder = Controls.Find("FrmBorder", true).FirstOrDefault();
                FrameHeight = Properties.Settings.Default.FrameHeight;
                FrameWidth = Properties.Settings.Default.FrameWidth;
                FrmBorder.Size = new Size(FrameHeight, FrameWidth);
            }
            else if (xo == "\u0010") //Strg + p || change path with folderpicker
            {
                fbd.SelectedPath = SavePath;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SavePath = fbd.SelectedPath;
                    Properties.Settings.Default.SavePath = SavePath;
                    Properties.Settings.Default.Save();
                }
            }
            else if (xo.ToLower() == "s")
            {
                UsrInf.UserInformationTxt = "Capturing...";
                UserInformation();

                CaptureScreen();
                UsrInf.UserInformationTxt = "Saving...";
                UserInformation();
                UsrInf.UserInformationTxt = "";
                UserInformation(500);
            }

        }

        private void CaptureScreen()
        {
            Bitmap memoryImage;
            memoryImage = new Bitmap(FrameWidth, FrameHeight);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(memoryImage);


            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;

            X = X - FrameWidth / 2;
            Y = Y - FrameHeight / 2;
            memoryGraphics.CopyFromScreen(X, Y, 0, 0, s);

            
            memoryImage.Save(SaveName(BasicName), System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        

        private string SaveName(string FileName)
        {
            String sCnt = "";

            String SvPth = SavePath + @"\" + FileName;
            String SvPth2 = SvPth + ".jpg";
            int Cnt = 0;

            while(File.Exists(@SvPth2) ==true)
            {
                Cnt += 1;
                sCnt = Cnt.ToString();
                SvPth2 = SvPth + sCnt + ".jpg";
            }
            SvPth = SvPth + sCnt;

            return SvPth + ".jpg";
        }
    }
}
