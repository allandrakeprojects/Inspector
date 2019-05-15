using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Inspector
{
    public partial class Main_Form : Form
    {
        private bool __isClose;
        private int __send = 0;
        private string __app = "Inspector";
        Form __mainForm_handler;

        // Drag Header to Move
        private bool m_aeroEnabled;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // ----- Drag Header to Move

        // Form Shadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }
        // ----- Form Shadow

        public Main_Form()
        {
            InitializeComponent();

            timer_landing.Start();
        }

        // Drag to Move
        private void panel_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            //Properties.Settings.Default.______last_bill_no = "";
            //Properties.Settings.Default.Save();
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_loader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_brand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel_landing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_landing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // ----- Drag to Move

        // Click Close
        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit the program?", __app, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                __isClose = true;
                Environment.Exit(0);
            }
        }

        // Click Minimize
        private void pictureBox_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Form Closing
        DialogResult _dr;
        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!__isClose)
            {
                timer_dialog.Start();
                _dr = MessageBox.Show("Exit the program?", __app, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        [DllImport("user32.dll")] public static extern IntPtr FindWindow(String sClassName, String sAppName);
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private void timer_dialog_Tick(object sender, EventArgs e)
        {
            IntPtr w = FindWindow(null, "FY FD Grab Exit");
            if (w != null) SendMessage(w, 0x0112, 0xF060, 0);
            timer_dialog.Stop();
        }

        // Form Load
        private void Main_Form_Load(object sender, EventArgs e)
        {
            dateTimePicker_start.Format = DateTimePickerFormat.Custom;
            dateTimePicker_start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_end.Format = DateTimePickerFormat.Custom;
            dateTimePicker_end.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        static int LineNumber([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }

        private void timer_landing_Tick(object sender, EventArgs e)
        {
            panel_landing.Visible = false;
            timer_landing.Stop();
            
            __mainForm_handler = Application.OpenForms[0];
            __mainForm_handler.Size = new Size(466, 249);
        }

        private void SendMyBot(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "772918363:AAHn2ufmP3ocLEilQ1V-IHcqYMcSuFJHx5g";
                string chatId = "@allandrake";
                string text = "-----" + __app + "-----%0A%0AIP:%20Reports Team PC%0ALocation:%20Robinsons Summit%0ADate%20and%20Time:%20[" + datetime + "]%0AMessage:%20" + message;
                urlString = String.Format(urlString, apiToken, chatId, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs);
                string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
            }
            catch (Exception err)
            {
                if (err.ToString().ToLower().Contains("hexadecimal"))
                {
                    string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                    string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                    string apiToken = "772918363:AAHn2ufmP3ocLEilQ1V-IHcqYMcSuFJHx5g";
                    string chatId = "@allandrake";
                    string text = "-----" + __app + "-----%0A%0AIP:%20Reports Team PC%0ALocation:%20Robinsons Summit%0ADate%20and%20Time:%20[" + datetime + "]%0AMessage:%20" + message;
                    urlString = String.Format(urlString, apiToken, chatId, text);
                    WebRequest request = WebRequest.Create(urlString);
                    Stream rs = request.GetResponse().GetResponseStream();
                    StreamReader reader = new StreamReader(rs);
                    string line = "";
                    StringBuilder sb = new StringBuilder();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                            sb.Append(line);
                    }

                    __isClose = false;
                    Environment.Exit(0);
                }
                else
                {
                    __send++;
                    if (__send == 5)
                    {
                        SendMyBot(err.ToString());

                        __isClose = false;
                        Environment.Exit(0);
                    }
                    else
                    {
                        ___WaitNSeconds(10);
                        SendMyBot(message);
                    }
                }
            }
        }

        //private void SendReportsTeam(string message)
        //{
        //    try
        //    {
        //        string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
        //        string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
        //        string apiToken = "762890741:AAFwjSml3OgWrN07G_41YgIIzFAyxYLGE8Q";
        //        string chatId = "@cronos_data_reports_team";
        //        string text = "Brand:%20-----" + __brand_code + "-----%0ATime:%20[" + datetime + "]%0AMessage:%20" + message + "";
        //        urlString = String.Format(urlString, apiToken, chatId, text);
        //        WebRequest request = WebRequest.Create(urlString);
        //        Stream rs = request.GetResponse().GetResponseStream();
        //        StreamReader reader = new StreamReader(rs);
        //        string line = "";
        //        StringBuilder sb = new StringBuilder();
        //        while (line != null)
        //        {
        //            line = reader.ReadLine();
        //            if (line != null)
        //                sb.Append(line);
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        __send++;
        //        if (__send == 5)
        //        {
        //            SendITSupport("There's a problem to the server, please re-open the application.");
        //            SendMyBot(err.ToString());

        //            isClose = false;
        //            Environment.Exit(0);
        //        }
        //        else
        //        {
        //            ___WaitNSeconds(10);
        //            SendReportsTeam(message);
        //        }
        //    }
        //}

        private void timer_flush_memory_Tick(object sender, EventArgs e)
        {
            ___FlushMemory();
        }

        public static void ___FlushMemory()
        {
            Process prs = Process.GetCurrentProcess();
            try
            {
                prs.MinWorkingSet = (IntPtr)(300000);
            }
            catch (Exception err)
            {
                // leave blank
            }
        }

        private void ___WaitNSeconds(int sec)
        {
            if (sec < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(sec);
            while (DateTime.Now < _desired)
            {
                Application.DoEvents();
            }
        }

        private void radioButton_fy_CheckedChanged(object sender, EventArgs e)
        {
            string color = "#DE1E70";
            Color color_change = ColorTranslator.FromHtml(color);
            panel1.BackColor = color_change;
            panel2.BackColor = color_change;
            label_title.Text = "FY Inspector";
            Text = "FY Inspector";
            
            radioButton1.Checked = false;
        }

        private void radioButton_tf_CheckedChanged(object sender, EventArgs e)
        {
            string color = "#9A0100";
            Color color_change = ColorTranslator.FromHtml(color);
            panel1.BackColor = color_change;
            panel2.BackColor = color_change;
            label_title.Text = "TF Inspector";
            Text = "TF Inspector";
            
            radioButton1.Checked = false;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                if (!String.IsNullOrEmpty(richTextBox_players.Text.Trim()))
                {
                    if (dateTimePicker_start.Text != dateTimePicker_end.Text)
                    {
                        string start_datetime = dateTimePicker_start.Text;
                        DateTime start = DateTime.Parse(start_datetime);

                        string end_datetime = dateTimePicker_end.Text;
                        DateTime end = DateTime.Parse(end_datetime);

                        string result_start = start.ToString("yyyy-MM-dd");
                        string result_end = end.ToString("yyyy-MM-dd");
                        string result_start_time = start.ToString("HH:mm:ss");
                        string result_end_time = end.ToString("HH:mm:ss");

                        if (start < end)
                        {
                            if (button_start.Text.ToLower() != "stop see magic!")
                            {
                                ___Is_Visible(false);
                                button_start.Text = "STOP SEE MAGIC!";
                                __timer_count = 10;
                                label_timer_count.Text = __timer_count.ToString();
                                __timer_count = 9;
                                label_timer_count.Visible = true;
                                timer_start.Start();
                            }
                            else
                            {
                                ___Is_Visible(true);
                                button_start.Text = "SEE MAGIC!";
                                __timer_count = 10;
                                label_timer_count.Visible = false;
                                timer_start.Stop();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Start Time is greater than End Time, that's not possible.", __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Provide proper date range.", __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    richTextBox_players.Text = "";
                    MessageBox.Show("Provide player/s.", __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBox_players.Focus();
                }
            }
            else
            {
                MessageBox.Show("Choose a brand.", __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void richTextBox_players_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show("New line as separator.", richTextBox_players);
        }

        private int __timer_count = 10;

        private void timer_start_Tick(object sender, EventArgs e)
        {
            label_timer_count.Text = __timer_count--.ToString();
            if (label_timer_count.Text == "-1")
            {
                panel_start.Visible = false;

                __mainForm_handler = Application.OpenForms[0];
                __mainForm_handler.Size = new Size(466, 468);

                if (radioButton_fy.Checked)
                {
                    webBrowser.Navigate("http://cs.ying168.bet/account/login");
                }
                else if (radioButton_tf.Checked)
                {
                    webBrowser.Navigate("http://cs.tianfa86.org/account/login");
                }

                webBrowser.Visible = true;
            }


            if (label_timer_count.Text == "2")
            {
                button_start.Text = "PREPARING MAGIC!";
            }
        }

        private void ___Is_Visible(bool bol)
        {
            radioButton_fy.Enabled = bol;
            radioButton_tf.Enabled = bol;
            richTextBox_players.Enabled = bol;
            dateTimePicker_start.Enabled = bol;
            dateTimePicker_end.Enabled = bol;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
