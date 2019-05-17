using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Inspector
{
    public partial class Main_Form : Form
    {
        private bool __is_close;
        private bool __maximize;
        private int __total_page;
        private int __current_count = 1;
        private int __send = 0;
        private int __secho = 0;
        private int __total_bet_record_ = 1;
        private int __timer_count = 10;
        private double __length = 5000;
        private double __total_record;
        private string __app = "Inspector";
        private string __url = "";
        private string __brand_code = "";
        private string __last_brand_code = "";
        private string __la = "";
        private string __player = "";
        private string __vip = "";
        List<String> __gp = new List<String>();
        StringBuilder __DATA = new StringBuilder();
        JObject __jo;
        JToken __jo_count;
        JToken __total_bet_record = null;
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
        private void Main_Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel_finish_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel_start_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel_status_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_finish_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_player_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_player_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_gp_count_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_gp_count_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_gp_name_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_gp_name_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_page_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_page_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_total_record_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_total_record_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_total_bet_record_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_select_brand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_select_player_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_start_time_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_end_time_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_timer_count_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_header_MouseDown(object sender, MouseEventArgs e)
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
                __is_close = true;
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
            if (!__is_close)
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
            timer_size.Start();
            __maximize = false;
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

                    __is_close = false;
                    Environment.Exit(0);
                }
                else
                {
                    __send++;
                    if (__send == 5)
                    {
                        SendMyBot(err.ToString());

                        __is_close = false;
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

        private void SendReportsTeam(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "762890741:AAFwjSml3OgWrN07G_41YgIIzFAyxYLGE8Q";
                string chatId = "@cronos_data_reports_team";
                string text = "Brand:%20-----" + __brand_code + "-----%0ATime:%20[" + datetime + "]%0AMessage:%20" + message + "";
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
                __send++;
                if (__send == 5)
                {
                    SendReportsTeam("There's a problem to the server, please re-open the application.");
                    SendMyBot(err.ToString());

                    __is_close = false;
                    Environment.Exit(0);
                }
                else
                {
                    ___WaitNSeconds(10);
                    SendReportsTeam(message);
                }
            }
        }

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
            __brand_code = "FY";

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
            __brand_code = "TF";

            radioButton1.Checked = false;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            richTextBox_players.Lines = richTextBox_players.Lines.Distinct().ToArray();
            richTextBox_players.Text = Regex.Replace(richTextBox_players.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);

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
                            if (button_start.Text.ToLower() != "stop" && button_start.Text.ToLower() != "preparing")
                            {
                                ___Is_Visible(false);
                                button_start.Text = "STOP";
                                __timer_count = 10;
                                label_timer_count.Text = __timer_count.ToString();
                                __timer_count = 9;
                                label_timer_count.Visible = true;
                                timer_start.Start();
                            }
                            else
                            {
                                ___Is_Visible(true);
                                button_start.Text = "START";
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

        private void timer_start_Tick(object sender, EventArgs e)
        {
            label_timer_count.Text = __timer_count--.ToString();
            if (label_timer_count.Text == "-1")
            {
                label_timer_count.Text = "";
                button_start.Text = "START";
                __timer_count = 10;
                label_timer_count.Visible = false;
                timer_start.Stop();

                if (__brand_code == "FY")
                {
                    __url = "http://cs.ying168.bet";
                }
                else if (__brand_code == "TF")
                {
                    __url = "http://cshk.tianfa86.org";
                }

                __maximize = true;
                __mainForm_handler = Application.OpenForms[0];
                __mainForm_handler.Size = new Size(466, 468);

                if (__brand_code != __last_brand_code)
                {
                    webBrowser.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
                    panel_start.Visible = false;
                    webBrowser.Navigate(__url + "/account/login");
                    webBrowser.Visible = true;
                }
                else
                {
                    panel_start.Visible = false;
                    ___FillUp();
                    webBrowser.Visible = false;
                    panel_status.Visible = true;
                    webBrowser.Navigate(__url + "/flow/wagered2");
                }
            }


            if (label_timer_count.Text == "2")
            {
                button_start.Text = "PREPARING";
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

        private void ___FillUp()
        {
            for (int i = 0; i <= richTextBox_players.Lines.Count() - 1; i++)
            {
                if (!String.IsNullOrEmpty(richTextBox_players.Lines[i].Trim()))
                {
                    if (i == 0)
                    {
                        dataGridView_player.Rows.Insert(0, i, richTextBox_players.Lines[i].Trim(), "Ongoing");
                        dataGridView_clone.Rows.Insert(0, i, richTextBox_players.Lines[i].Trim(), "Ongoing");
                    }
                    else
                    {
                        dataGridView_player.Rows.Insert(0, i, richTextBox_players.Lines[i].Trim(), "Pending");
                        dataGridView_clone.Rows.Insert(0, i, richTextBox_players.Lines[i].Trim(), "Pending");
                    }
                    
                    __player += i + "|" + richTextBox_players.Lines[i].Trim() + "*|*";
                }
            }

            dataGridView_player.Sort(dataGridView_player.Columns["id"], ListSortDirection.Ascending);
            dataGridView_clone.Sort(dataGridView_clone.Columns["id_clone"], ListSortDirection.Ascending);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url == webBrowser.Url)
                {
                    try
                    {
                        if (webBrowser.Url.ToString().Equals(__url + "/account/login"))
                        {
                            webBrowser.Visible = true;
                            webBrowser.BringToFront();
                            webBrowser.Document.Window.ScrollTo(0, 180);
                            if (__brand_code == "FY")
                            {
                                webBrowser.Document.GetElementById("csname").SetAttribute("value", "fycronos2");
                                webBrowser.Document.GetElementById("cspwd").SetAttribute("value", "cronos12345");
                            }
                            else if (__brand_code == "TF")
                            {
                                webBrowser.Document.GetElementById("csname").SetAttribute("value", "tfcronos2");
                                webBrowser.Document.GetElementById("cspwd").SetAttribute("value", "cronos12345");
                            }
                            webBrowser.Document.GetElementById("csname").Enabled = false;
                            webBrowser.Document.GetElementById("cspwd").Enabled = false;
                            webBrowser.Document.GetElementById("la").Enabled = false;
                            __la = webBrowser.Document.GetElementById("la").GetAttribute("value");

                            if (__la == "")
                            {
                                SendReportsTeam("There's a problem to the server, please re-open the application.");

                                __is_close = false;
                                Environment.Exit(0);
                            }
                        }

                        if (webBrowser.Url.ToString().Equals(__url + "/player/list") || webBrowser.Url.ToString().Equals(__url + "/site/index") || webBrowser.Url.ToString().Equals(__url + "/player/online") || webBrowser.Url.ToString().Equals(__url + "/message/platform"))
                        {
                            ___FillUp();

                            webBrowser.Visible = false;
                            panel_status.Visible = true;
                            webBrowser.Navigate(__url + "/flow/wagered2");
                        }

                        if (webBrowser.Url.ToString().Equals(__url + "/flow/wagered2"))
                        {
                            __gp.Clear();
                            HtmlElement selectF8 = webBrowser.Document.GetElementById("gpid");
                            foreach (HtmlElement item in selectF8.Children)
                            {
                                if (item.InnerText != "全选")
                                {
                                    __gp.Add(item.GetAttribute("value") + "*|*" + item.InnerText);
                                }
                            }

                            // ---------- PROCESS STARTS HERE
                            __last_brand_code = __brand_code;
                            ___PROCESSAsync();
                        }
                    }
                    catch (Exception err)
                    {

                    }
                }
            }
        }

        private async void ___PROCESSAsync()
        {
            try
            {
                string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                foreach (string _player in _players)
                {
                    if (!String.IsNullOrEmpty(_player))
                    {
                        string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                        if (richTextBox_players.Lines.Count() == 1)
                        {
                            label_player.Text = _players_inner[1];
                        }
                        else
                        {
                            label_player.Text = _players_inner[1] + " (" + (Convert.ToInt32(_players_inner[0]) + 1) + " of " + richTextBox_players.Lines.Count() + ")";
                        }
                        await ___PROCESS_ifexistsAsync(_players_inner[1]);
                    }
                }
            }
            catch (Exception err)
            {
                SendMyBot(err.ToString());
                MessageBox.Show(err.ToString());
            }
            
            // ---------- FINISH
            label_player.Text = "-";
            ___PROCESSS_clear();
            panel_status.Visible = false;
            panel_finish.Visible = true;
        }

        private async Task ___PROCESS_ifexistsAsync(string player)
        {
            var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
            WebClient wc = new WebClient();
            wc.Headers.Add("Cookie", cookie);
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var reqparm = new NameValueCollection
            {
                {"s_btype", ""},
                {"skip", "0"},
                {"s_type", "1"},
                {"s_keyword", player},
                {"s_searchexact", "0"},
                {"s_type5", "10"},
                {"s_keyword5", ""},
                {"s_type3", "3"},
                {"s_keyword3", ""},
                {"groupid", "0"},
                {"s_playercurrency", "ALL"},
                {"s_type2", "4"},
                {"s_keyword2", "0"},
                {"s_searchexact2", "0"},
                {"s_type6", "14"},
                {"s_keyword6", ""},
                {"s_type4", "17"},
                {"s_keyword4", ""},
                {"s_status_search", ""},
                {"regday_start", ""},
                {"regday_end", ""},
                {"logintime_start", ""},
                {"logintime_end", ""},
                {"min_balance", ""},
                {"max_balance", ""},
                {"min_c_income", ""},
                {"max_c_income", ""},
                {"excludeLockID", "{}"},
                {"data[0][name]", "sEcho"},
                {"data[0][value]", __secho++.ToString()},
                {"data[1][name]", "iColumns"},
                {"data[1][value]", "18"},
                {"data[2][name]", "sColumns"},
                {"data[2][value]", ",,,,,,,balance,comwl,,,,,,,,,"},
                {"data[3][name]", "iDisplayStart"},
                {"data[3][value]", "0"},
                {"data[4][name]", "iDisplayLength"},
                {"data[4][value]", "5000"}
            };

            byte[] result = await wc.UploadValuesTaskAsync(__url + "/player/listAjax2", "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(result);
            var deserialize_object = JsonConvert.DeserializeObject(responsebody);
            JObject jo = JObject.Parse(deserialize_object.ToString());
            JToken jt_total = jo.SelectToken("$.iTotalRecords");
            if (jt_total.ToString() != "0")
            {
                bool _is_found = false;
                for (int i = 0; i < Convert.ToInt32(jt_total) ; i++)
                {
                    JToken _username = jo.SelectToken("$.aaData[" + i + "][0]");
                    string username = "";
                    try
                    {
                        username = Regex.Match(_username.ToString(), "username=\\\"(.*?)\\\"").Groups[1].Value;
                    }
                    catch (Exception err)
                    {
                        SendMyBot(_username.ToString());
                    }
                    if (username == player)
                    {
                        JToken _vip = jo.SelectToken("$.aaData[" + i + "][5]");
                        if (_vip.ToString().ToLower().Contains("label"))
                        {
                            __vip = Regex.Match(_vip.ToString(), "<label(.*?)>(.*?)</label>").Groups[2].Value;
                        }
                        else
                        {
                            __vip = _vip.ToString();
                        }

                        _is_found = true;
                        string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                        foreach (string _player in _players)
                        {
                            if (!String.IsNullOrEmpty(_player))
                            {
                                string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                                if (_players_inner[1] == player)
                                {
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "Ongoing";
                                    dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "Ongoing";
                                    break;
                                }
                            }
                        }

                        // ---------- GETTING STARTS HERE
                        await ___PROCESS_calculatingAsync(player);

                        break;
                    }
                }

                if (!_is_found)
                {
                    string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                    foreach (string _player in _players)
                    {
                        if (!String.IsNullOrEmpty(_player))
                        {
                            string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                            if (_players_inner[1] == player)
                            {
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "Not Found";
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };

                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "Not Found";
                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };
                                
                                try
                                {
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0]) + 1].Cells[2].Value = "Ongoing";
                                    dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0]) + 1].Cells[2].Value = "Ongoing";
                                }
                                catch (Exception err)
                                {
                                    // leave blank
                                }

                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                foreach (string _player in _players)
                {
                    if (!String.IsNullOrEmpty(_player))
                    {
                        string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                        if (_players_inner[1] == player)
                        {
                            dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "Not Found";
                            dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };

                            dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "Not Found";
                            dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };
                            
                            try
                            {
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0]) + 1].Cells[2].Value = "Ongoing";
                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0]) + 1].Cells[2].Value = "Ongoing";
                            }
                            catch (Exception err)
                            {
                                // leave blank
                            }

                            break;
                        }
                    }
                }
            }
        }
        
        private async Task ___PROCESS_calculatingAsync(string player)
        {
            __total_record = 0;
            __total_page = 0;

            var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
            WebClient wc = new WebClient();
            wc.Headers.Add("Cookie", cookie);
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            // all
            if (label_total_bet_record.Text == "-")
            {
                var reqparm = new NameValueCollection
                {
                    {"s_btype", ""},
                    {"betNo", ""},
                    {"name", player},
                    {"gpid", "0"},
                    {"orderNum", ""},
                    {"wager_settle", "0"},
                    {"valid_inva", ""},
                    {"start",  dateTimePicker_start.Text},
                    {"end", dateTimePicker_end.Text},
                    {"skip", "0"},
                    {"ftime_188", "bettime"},
                    {"data[0][name]", "sEcho"},
                    {"data[0][value]", __secho++.ToString()},
                    {"data[1][name]", "iColumns"},
                    {"data[1][value]", "12"},
                    {"data[2][name]", "sColumns"},
                    {"data[2][value]", ""},
                    {"data[3][name]", "iDisplayStart"},
                    {"data[3][value]", "0"},
                    {"data[4][name]", "iDisplayLength"},
                    {"data[4][value]", "1"}
                };
                byte[] result_gettotal_bet = await wc.UploadValuesTaskAsync(__url + "/flow/wageredAjax2", "POST", reqparm);
                string responsebody_gettotatal_bet = Encoding.UTF8.GetString(result_gettotal_bet);
                var deserializeObject_gettotal_bet = JsonConvert.DeserializeObject(responsebody_gettotatal_bet);
                JObject jo_gettotal_bet = JObject.Parse(deserializeObject_gettotal_bet.ToString());
                __total_bet_record = jo_gettotal_bet.SelectToken("$.iTotalRecords");
                label_total_bet_record.Text = "0 of " + Convert.ToInt32(__total_bet_record).ToString("N0");
            }

            // gp
            int count = 1;
            string gpid = "";
            foreach (var gp in __gp)
            {
                if (count == __current_count)
                {
                    string[] line = gp.Split(new string[] { "*|*" }, StringSplitOptions.None);
                    gpid = line[0];
                    label_gp_name.Text = line[1];
                    break;
                }

                count++;
            }
            label_gp_count.Text = __current_count + " of " + (__gp.Count).ToString("N0");
            var reqparm1 = new NameValueCollection
            {
                {"s_btype", ""},
                {"betNo", ""},
                {"name", player},
                {"gpid", gpid},
                {"orderNum", ""},
                {"wager_settle", gpid},
                {"valid_inva", ""},
                {"start",  dateTimePicker_start.Text},
                {"end", dateTimePicker_end.Text},
                {"skip", "0"},
                {"ftime_188", "bettime"},
                {"data[0][name]", "sEcho"},
                {"data[0][value]", __secho++.ToString()},
                {"data[1][name]", "iColumns"},
                {"data[1][value]", "12"},
                {"data[2][name]", "sColumns"},
                {"data[2][value]", ""},
                {"data[3][name]", "iDisplayStart"},
                {"data[3][value]", "0"},
                {"data[4][name]", "iDisplayLength"},
                {"data[4][value]", "1"}
            };
            byte[] result_gettotal = await wc.UploadValuesTaskAsync(__url + "/flow/wageredAjax2", "POST", reqparm1);
            string responsebody_gettotatal = Encoding.UTF8.GetString(result_gettotal);
            var deserializeObject_gettotal = JsonConvert.DeserializeObject(responsebody_gettotatal);
            JObject jo_gettotal = JObject.Parse(deserializeObject_gettotal.ToString());
            JToken jt_gettotal = jo_gettotal.SelectToken("$.iTotalRecords");
            if (String.IsNullOrEmpty(jt_gettotal.ToString()))
            {
                jt_gettotal = 0;
            }
            __total_record += double.Parse(jt_gettotal.ToString());
            double get_total_records_fy = 0;
            get_total_records_fy = double.Parse(jt_gettotal.ToString());
            double result_total_records = get_total_records_fy / __length;
            if (result_total_records.ToString().Contains("."))
            {
                __total_page += Convert.ToInt32(Math.Floor(result_total_records)) + 1;
            }
            else
            {
                __total_page += Convert.ToInt32(Math.Floor(result_total_records));
            }
            label_page.Text = "0 of " + __total_page.ToString("N0");
            label_total_record.Text = "0 of " + Convert.ToInt32(__total_record).ToString("N0");
            
            if (__total_page == 0)
            {
                if (__current_count == __gp.Count)
                {
                    // leave blank
                    if (!String.IsNullOrEmpty(__DATA.ToString()))
                    {
                        ___PROCESS_excel(player);
                        string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                        foreach (string _player in _players)
                        {
                            if (!String.IsNullOrEmpty(_player))
                            {
                                string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                                if (_players_inner[1] == player)
                                {
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "OK";
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Chartreuse, SelectionForeColor = Color.Chartreuse };

                                    dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "OK";
                                    dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Chartreuse, SelectionForeColor = Color.Chartreuse };
                                    
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                        foreach (string _player in _players)
                        {
                            if (!String.IsNullOrEmpty(_player))
                            {
                                string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                                if (_players_inner[1] == player)
                                {
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "No Data";
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };

                                    dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "No Data";
                                    dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };
                                    
                                    break;
                                }
                            }
                        }
                    }

                    ___PROCESSS_clear();
                }
                else
                {
                    __current_count++;
                    await ___PROCESS_calculatingAsync(player);
                }
            }
            else
            {
                await ___PROCESS_gettingAsync(player);
            }

        }

        private async Task ___PROCESS_gettingAsync(string player)
        {
            var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
            WebClient wc = new WebClient();
            wc.Headers.Add("Cookie", cookie);
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            int count = 1;
            string gpid = "";
            foreach (var gp in __gp)
            {
                if (count == __current_count)
                {
                    string[] line = gp.Split(new string[] { "*|*" }, StringSplitOptions.None);
                    gpid = line[0];
                    label_gp_name.Text = line[1];
                    break;
                }

                count++;
            }
            label_gp_count.Text = __current_count + " of " + (__gp.Count).ToString("N0");
            // Bet Record
            var reqparm = new NameValueCollection
            {
                {"s_btype", ""},
                {"betNo", ""},
                {"name", player},
                {"gpid", gpid},
                {"orderNum", ""},
                {"wager_settle", gpid},
                {"valid_inva", ""},
                {"start",  dateTimePicker_start.Text},
                {"end", dateTimePicker_end.Text},
                {"skip", "0"},
                {"ftime_188", "bettime"},
                {"data[0][name]", "sEcho"},
                {"data[0][value]", __secho++.ToString()},
                {"data[1][name]", "iColumns"},
                {"data[1][value]", "12"},
                {"data[2][name]", "sColumns"},
                {"data[2][value]", ""},
                {"data[3][name]", "iDisplayStart"},
                {"data[3][value]", "0"},
                {"data[4][name]", "iDisplayLength"},
                {"data[4][value]", __length.ToString()}
            };

            byte[] result = await wc.UploadValuesTaskAsync(__url + "/flow/wageredAjax2", "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(result);
            var deserializeObject = JsonConvert.DeserializeObject(responsebody);
            __jo = JObject.Parse(deserializeObject.ToString());
            __jo_count = __jo.SelectToken("$.aaData");

            int _total_record = 1;

            label_page.Text = "1 of " + __total_page.ToString("N0");
            label_page.Invalidate();
            label_page.Update();

            for (int i_page = 0; i_page < __total_page; i_page++)
            {
                for (int i = 0; i < __jo_count.Count(); i++)
                {
                    Application.DoEvents();

                    // -----------------------------------
                    // Bet Record
                    JToken game_platform = __jo.SelectToken("$.aaData[" + i + "][1]");
                    JToken player_id = __jo.SelectToken("$.aaData[" + i + "][2][0]");
                    JToken player_name = __jo.SelectToken("$.aaData[" + i + "][2][1]");
                    JToken bet_no = __jo.SelectToken("$.aaData[" + i + "][3]").ToString().Replace("BetTransaction:", "");
                    JToken bet_time = __jo.SelectToken("$.aaData[" + i + "][4]");

                    // updated 01/10/2019
                    JToken bet_type = __jo.SelectToken("$.aaData[" + i + "][5]").ToString();
                    if (!game_platform.ToString().Contains("VR"))
                    {
                        var match = Regex.Match(bet_type.ToString(), @"<div\b[^>]*>(.*?)<\/div>");
                        if (match.Success)
                        {
                            string bet_type_replace = match.Groups[1].Value;
                            bet_type_replace = bet_type_replace.Replace("<br/>", "");
                            bet_type_replace = bet_type_replace.Replace("<div>", "");
                            bet_type_replace = bet_type_replace.Replace("</div>", "");
                            bet_type_replace = bet_type_replace.Replace("<span>", "");
                            bet_type_replace = bet_type_replace.Replace("</span>", "");
                            bet_type_replace = bet_type_replace.Replace(",", "");
                            bet_type_replace = bet_type_replace.Replace("，", "");
                            bet_type = bet_type_replace.PadRight(225).Substring(0, 225).Trim();
                        }
                        else
                        {
                            string bet_type_replace = bet_type.ToString();
                            bet_type_replace = bet_type_replace.Replace("<br/>", "");
                            bet_type_replace = bet_type_replace.Replace("<div>", "");
                            bet_type_replace = bet_type_replace.Replace("</div>", "");
                            bet_type_replace = bet_type_replace.Replace("<span>", "");
                            bet_type_replace = bet_type_replace.Replace("</span>", "");
                            bet_type_replace = bet_type_replace.Replace(",", "");
                            bet_type_replace = bet_type_replace.Replace("，", "");
                            bet_type = bet_type_replace.PadRight(225).Substring(0, 225).Trim();
                        }
                    }
                    else
                    {
                        string[] bet_type_get = bet_type.ToString().Split(new string[] { "<br/>" }, StringSplitOptions.None);
                        bet_type = bet_type_get[0];
                    }
                    String result_bet_type = Regex.Replace(bet_type.ToString(), @"<[^>]*>", String.Empty);

                    JToken game_result = __jo.SelectToken("$.aaData[" + i + "][6]").ToString().Replace("<br>", "");
                    JToken stake_amount_color = __jo.SelectToken("$.aaData[" + i + "][7][0]");
                    JToken stake_amount = __jo.SelectToken("$.aaData[" + i + "][7][1]");
                    JToken win_amount_color = __jo.SelectToken("$.aaData[" + i + "][8][0]");
                    JToken win_amount = __jo.SelectToken("$.aaData[" + i + "][8][1]");
                    JToken company_win_loss_color = __jo.SelectToken("$.aaData[" + i + "][9][0]");
                    JToken company_win_loss = __jo.SelectToken("$.aaData[" + i + "][9][1]");
                    JToken valid_bet_color = __jo.SelectToken("$.aaData[" + i + "][10][0]");
                    JToken valid_bet = __jo.SelectToken("$.aaData[" + i + "][10][1]");
                    JToken valid_invalid_id = __jo.SelectToken("$.aaData[" + i + "][11][0]");
                    JToken valid_invalid = __jo.SelectToken("$.aaData[" + i + "][11][1]");
                    string bet_time_date = bet_time.ToString().Substring(0, 10);
                    DateTime month = DateTime.ParseExact(bet_time_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    // get vip
                    // asd comment
                    string vip = "";

                    //for (int i_ = 0; i_ < getmemberlist_fy.Count; i_ += 2)
                    //{
                    //    if (getmemberlist_fy[i_] == player_name.ToString())
                    //    {
                    //        vip = getmemberlist_fy[i_ + 1];
                    //        break;
                    //    }
                    //}

                    // asd turnover
                    // provider
                    // category

                    if (__total_bet_record_ == 1)
                    {
                        var header = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", "Month", "Date", "VIP", "Game Platform", "Username", "Bet No", "Bet Time", "Bet Type", "Game Result", "Stake Amount", "Win Amount", "Company Win/Loss", "Valid Bet", "Valid/Invalid");
                        __DATA.AppendLine(header);
                    }

                    result_bet_type = result_bet_type.ToString().Replace(";", "");
                    string result_bet_type_replace = Regex.Replace(result_bet_type, @"\t|\n|\r", "");

                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", "\"" + month.ToString("MM/01/yyyy") + "\"", "\"" + bet_time_date + "\"", "\"" + __vip + "\"", "\"" + game_platform + "\"", "\"" + player_name + "\"", "\"" + "'" + bet_no + "\"", "\"" + bet_time + "\"", "\"" + result_bet_type_replace + "\"", "\"" + game_result + "\"", "\"" + stake_amount + "\"", "\"" + win_amount + "\"", "\"" + company_win_loss + "\"", "\"" + valid_bet + "\"", "\"" + valid_invalid + "\"");
                    __DATA.AppendLine(newLine);
                    // -----------------------------------

                    label_total_record.Text = _total_record.ToString("N0") + " of " + __total_record.ToString("N0");
                    label_total_bet_record.Text = __total_bet_record_.ToString("N0") + " of " + Convert.ToInt32(__total_bet_record).ToString("N0");
                    __total_bet_record_++;
                    _total_record++;
                    label_total_record.Invalidate();
                    label_total_record.Update();
                    label_total_bet_record.Invalidate();
                    label_total_bet_record.Update();
                }

                if (__total_page != 1)
                {
                    await ___PROCESS_pageAsync(player, i_page + 1);
                    if (i_page + 2 <= __total_page)
                    {
                        label_page.Text = (i_page + 2).ToString("N0") + " of " + __total_page.ToString("N0");
                        label_page.Invalidate();
                        label_page.Update();
                    }
                }
            }
            
            if (__current_count == __gp.Count)
            {
                // leave blank
                if (!String.IsNullOrEmpty(__DATA.ToString()))
                {
                    ___PROCESS_excel(player);
                    string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                    foreach (string _player in _players)
                    {
                        if (!String.IsNullOrEmpty(_player))
                        {
                            string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                            if (_players_inner[1] == player)
                            {
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "OK";
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Chartreuse, SelectionForeColor = Color.Chartreuse };

                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "OK";
                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Chartreuse, SelectionForeColor = Color.Chartreuse };
                                
                                break;
                            }
                        }
                    }
                }
                else
                {
                    string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
                    foreach (string _player in _players)
                    {
                        if (!String.IsNullOrEmpty(_player))
                        {
                            string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                            if (_players_inner[1] == player)
                            {
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "No Data";
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };

                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "No Data";
                                dataGridView_clone.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, SelectionForeColor = Color.DarkRed };
                                
                                break;
                            }
                        }
                    }
                }

                ___PROCESSS_clear();
            }
            else
            {
                __current_count++;
                await ___PROCESS_calculatingAsync(player);
            }
        }

        private async Task ___PROCESS_pageAsync(string player, double page)
        {
            var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
            WebClient wc = new WebClient();
            wc.Headers.Add("Cookie", cookie);
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            int count = 1;
            string gpid = "";
            foreach (var gp in __gp)
            {
                if (count == __current_count)
                {
                    string[] line = gp.Split(new string[] { "*|*" }, StringSplitOptions.None);
                    gpid = line[0];
                    label_gp_name.Text = line[1];
                    break;
                }

                count++;
            }
            label_gp_count.Text = __current_count + " of " + (__gp.Count).ToString("N0");
            // Bet Record
            var reqparm = new NameValueCollection
            {
                {"s_btype", ""},
                {"betNo", ""},
                {"name", player},
                {"gpid", gpid},
                {"orderNum", ""},
                {"wager_settle", gpid},
                {"valid_inva", ""},
                {"start",  dateTimePicker_start.Text},
                {"end", dateTimePicker_end.Text},
                {"skip", "0"},
                {"ftime_188", "bettime"},
                {"data[0][name]", "sEcho"},
                {"data[0][value]", __secho++.ToString()},
                {"data[1][name]", "iColumns"},
                {"data[1][value]", "12"},
                {"data[2][name]", "sColumns"},
                {"data[2][value]", ""},
                {"data[3][name]", "iDisplayStart"},
                {"data[3][value]", (page * __length).ToString()},
                {"data[4][name]", "iDisplayLength"},
                {"data[4][value]", __length.ToString()}
            };

            byte[] result = await wc.UploadValuesTaskAsync(__url + "/flow/wageredAjax2", "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(result);
            var deserializeObject = JsonConvert.DeserializeObject(responsebody);
            __jo = JObject.Parse(deserializeObject.ToString());
            __jo_count = __jo.SelectToken("$.aaData");
        }

        private void ___PROCESS_excel(string player)
        {
            string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string datetime = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Directory.Exists(desktop_path + "\\Inspector"))
            {
                Directory.CreateDirectory(desktop_path + "\\Inspector");
            }

            if (!Directory.Exists(desktop_path + "\\Inspector\\" + __brand_code))
            {
                Directory.CreateDirectory(desktop_path + "\\Inspector\\" + __brand_code);
            }

            if (!Directory.Exists(desktop_path + "\\Inspector\\" + __brand_code + "\\" + datetime))
            {
                Directory.CreateDirectory(desktop_path + "\\Inspector\\" + __brand_code + "\\" + datetime);
            }

            string path = desktop_path + "\\Inspector\\" + __brand_code + "\\" + datetime + "\\" + dateTimePicker_start.Text.Substring(0, 10) + "_" + dateTimePicker_start.Text.Substring(11, 8).Replace(":", "").Trim() + "__" + dateTimePicker_end.Text.Substring(0, 10) + "_" + dateTimePicker_end.Text.Substring(11, 8).Replace(":", "").Trim() + "___" + player + ".xlsx";
            string path_text = desktop_path + "\\Inspector\\" + __brand_code + "\\" + datetime + "\\" + dateTimePicker_start.Text.Substring(0, 10) + "__" + dateTimePicker_end.Text.Substring(0, 10) + "___" + player + ".txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (File.Exists(path_text))
            {
                File.Delete(path_text);
            }

            File.WriteAllText(path_text, __DATA.ToString(), Encoding.UTF8);

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(path_text, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet worksheet = wb.ActiveSheet;
            worksheet.Activate();
            worksheet.Application.ActiveWindow.SplitRow = 1;
            worksheet.Application.ActiveWindow.FreezePanes = true;
            Excel.Range firstRow = (Excel.Range)worksheet.Rows[1];
            firstRow.AutoFilter(1,
                                Type.Missing,
                                Excel.XlAutoFilterOperator.xlAnd,
                                Type.Missing,
                                true);
            Excel.Range usedRange = worksheet.UsedRange;
            Excel.Range rows = usedRange.Rows;
            int count = 0;
            foreach (Excel.Range row in rows)
            {
                if (count == 0)
                {
                    Excel.Range firstCell = row.Cells[1];

                    string firstCellValue = firstCell.Value as String;

                    if (!string.IsNullOrEmpty(firstCellValue))
                    {
                        if (__brand_code == "FY")
                        {
                            row.Interior.Color = Color.FromArgb(222, 30, 112);
                        }
                        else if (__brand_code == "TF")
                        {
                            row.Interior.Color = Color.FromArgb(154, 0, 0);
                        }
                        row.Font.Color = Color.FromArgb(255, 255, 255);
                        row.Font.Bold = true;
                        row.Font.Size = 12;
                    }

                    break;
                }

                count++;
            }
            int i_excel;
            for (i_excel = 1; i_excel <= 20; i_excel++)
            {
                worksheet.Columns[i_excel].ColumnWidth = 20;
            }
            wb.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.Close();
            app.Quit();
            Marshal.ReleaseComObject(app);
            
            if (File.Exists(path_text))
            {
                File.Delete(path_text);
            }
        }

        private void ___PROCESSS_clear()
        {
            label_page.Text = "-";
            label_total_record.Text = "-";
            label_gp_name.Text = "-";
            label_gp_count.Text = "-";
            label_total_bet_record.Text = "-";

            __total_page = 0;
            __current_count = 1;
            __total_bet_record_ = 1;
            __total_record = 0;
            __jo = null;
            __jo_count = null;
            __total_bet_record = null;
            __DATA.Clear();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            _dr = MessageBox.Show("Exit the program?", __app, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_dr == DialogResult.Yes)
            {
                __is_close = false;
                Environment.Exit(0);
            }
        }

        private void button_retry_Click(object sender, EventArgs e)
        {
            __maximize = false;
            __mainForm_handler = Application.OpenForms[0];
            __mainForm_handler.Size = new Size(466, 238);

            __player = "";
            __gp.Clear();
            dataGridView_player.Rows.Clear();
            dataGridView_player.ClearSelection();
            dataGridView_clone.Rows.Clear();
            dataGridView_clone.ClearSelection();
            panel_finish.Visible = false;
            panel_start.Visible = true;
            ___Is_Visible(true);
            ___PROCESSS_clear();
        }

        private void timer_size_Tick(object sender, EventArgs e)
        {
            if (__maximize)
            {
                __mainForm_handler = Application.OpenForms[0];
                __mainForm_handler.Size = new Size(466, 468);
            }
            else
            {
                __mainForm_handler = Application.OpenForms[0];
                __mainForm_handler.Size = new Size(466, 238);
            }
        }
    }
}
