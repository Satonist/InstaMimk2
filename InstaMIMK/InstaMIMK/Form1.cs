using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaMIMK
{
    public partial class Form1 : Form
    {
        Size resolution = Screen.PrimaryScreen.Bounds.Size;
        int skrinX, skrinY;

        public Form1()
        {
            InitializeComponent();
            SkrinX = Resolution.Width;
            SkrinY = Resolution.Height;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(SkrinX / 5, SkrinY / 5);
        }

        #region Form
        #region mouse_move
        private const int wM_NCLBUTTONDOWN = 0xA1;
        private const int hT_CAPTION = 0x2;

        public Size Resolution { get => resolution; set => resolution = value; }
        public int SkrinX { get => skrinX; set => skrinX = value; }
        public int SkrinY { get => skrinY; set => skrinY = value; }

        public static int WM_NCLBUTTONDOWN => wM_NCLBUTTONDOWN;

        public static int HT_CAPTION => hT_CAPTION;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion mouse_move

        #region BttnForm
        private void BttnCloseImg_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        
        private void BttnMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion BttnForm
        #endregion Form

        #region EnterPage
        #region Bttn
        private void BttnRegistration_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = RegistrationPage;
        }
        private void BttnEnter_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = MainPage;
        }
        #endregion Bttn

        #region TextBox
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if(EnterLoginTxt.Text== "Логин")
                EnterLoginTxt.Text = "";
        }
        private void Password_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnterPasswordTxt.Text == "Пароль")
                EnterPasswordTxt.Text = "";
        }
        #endregion TextBox
        #endregion EnterPage

        #region RegistrationPage
        private void bttnRegistration2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = EnterPage;
        }
        #endregion RegistrationPage

        #region bttnMenu
        private void bttnMyPage_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = MainPage;
        }

        private void bttnMessagePage_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = MessagePage;
        }

        private void bttnSettingsPage_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SetingsPage;
        }

        #endregion bttnMenu

        #region MainPage

        #endregion MainPage

        #region MessagePage

        #endregion MessagePage

        #region SettingsPage

        #endregion SettingsPage

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
