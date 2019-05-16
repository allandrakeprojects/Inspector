using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inspector
{
    public partial class Main_Form : Form
    {
        private bool __is_close;
        private int __send = 0;
        private int __secho = 0;
        private string __app = "Inspector";
        private string __brand_code = "";
        private string __la = "";
        private string __player = "";
        List<String> __gp = new List<String>();
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
            dateTimePicker_start.CustomFormat = "yyyy-04-dd HH:mm:ss";
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
            
            //__mainForm_handler = Application.OpenForms[0];
            //__mainForm_handler.Size = new Size(466, 249);
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
                            if (button_start.Text.ToLower() != "stop see magic!" && button_start.Text.ToLower() != "preparing magic!")
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

                //__mainForm_handler = Application.OpenForms[0];
                //__mainForm_handler.Size = new Size(466, 468);

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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= richTextBox_players.Lines.Count() - 1; i++)
            {
                if (!String.IsNullOrEmpty(richTextBox_players.Lines[i]))
                {
                    if (i == 0)
                    {
                        dataGridView_player.Rows.Insert(0, i, richTextBox_players.Lines[i], "Ongoing");
                    }
                    else
                    {
                        dataGridView_player.Rows.Insert(0, i, richTextBox_players.Lines[i], "Pending");
                    }

                    __player += i + "|" + richTextBox_players.Lines[i] + "*|*";
                }
            }
            
            dataGridView_player.Sort(dataGridView_player.Columns["id"], ListSortDirection.Ascending);

            //dataGridView_player.DefaultCellStyle.SelectionBackColor = dataGridView_player.DefaultCellStyle.BackColor;
            //dataGridView_player.DefaultCellStyle.SelectionForeColor = dataGridView_player.DefaultCellStyle.ForeColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
            //foreach (string _player in _players)
            //{
            //    if (!String.IsNullOrEmpty(_player))
            //    {
            //        string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
            //        if (_players_inner[1] == "asd123")
            //        {
            //            dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Value = "OK";
            //            dataGridView_player.Rows[Convert.ToInt32(_players_inner[0])].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Chartreuse, SelectionForeColor = Color.Chartreuse };
            //        }
            //    }
            //}
        }

        private void ___FillUp()
        {
            for (int i = 0; i <= richTextBox_players.Lines.Count() - 1; i++)
            {
                if (!String.IsNullOrEmpty(richTextBox_players.Lines[i]))
                {
                    if (i == 0)
                    {
                        dataGridView_player.Rows.Insert(0, i, richTextBox_players.Lines[i], "Ongoing");
                    }
                    else
                    {
                        dataGridView_player.Rows.Insert(0, i, richTextBox_players.Lines[i], "Pending");
                    }

                    __player += i + "|" + richTextBox_players.Lines[i] + "*|*";
                }
            }

            dataGridView_player.Sort(dataGridView_player.Columns["id"], ListSortDirection.Ascending);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url == webBrowser.Url)
                {
                    try
                    {
                        if (webBrowser.Url.ToString().Equals("http://cs.ying168.bet/account/login"))
                        {
                            webBrowser.Visible = true;
                            webBrowser.BringToFront();
                            webBrowser.Document.Window.ScrollTo(0, 180);
                            webBrowser.Document.GetElementById("csname").SetAttribute("value", "fycronos2");
                            webBrowser.Document.GetElementById("cspwd").SetAttribute("value", "cronos12345");
                            webBrowser.Document.GetElementById("la").Enabled = false;
                            __la = webBrowser.Document.GetElementById("la").GetAttribute("value");

                            if (__la == "")
                            {
                                SendReportsTeam("There's a problem to the server, please re-open the application.");

                                __is_close = false;
                                Environment.Exit(0);
                            }
                        }

                        if (webBrowser.Url.ToString().Equals("http://cs.ying168.bet/player/list") || webBrowser.Url.ToString().Equals("http://cs.ying168.bet/site/index") || webBrowser.Url.ToString().Equals("http://cs.ying168.bet/player/online") || webBrowser.Url.ToString().Equals("http://cs.ying168.bet/message/platform"))
                        {
                            ___FillUp();

                            webBrowser.Visible = false;
                            webBrowser.Navigate("http://cs.ying168.bet/flow/wagered2");
                        }

                        if (webBrowser.Url.ToString().Equals("http://cs.ying168.bet/flow/wagered2"))
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

                            // Process Starts Here
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
            string[] _players = __player.Split(new string[] { "*|*" }, StringSplitOptions.None);
            foreach (string _player in _players)
            {
                if (!String.IsNullOrEmpty(_player))
                {
                    string[] _players_inner = _player.Split(new string[] { "|" }, StringSplitOptions.None);
                    await ___PROCESS_ifexistsAsync(_players_inner[1]);
                }
            }

            MessageBox.Show("Done!");
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
                {"data[4][value]", "100"}
            };

            byte[] result = await wc.UploadValuesTaskAsync("http://cs.ying168.bet/player/listAjax2", "POST", reqparm);
            string responsebody = "";
            if (__la == "en")
            {
                responsebody = Encoding.UTF8.GetString(result).Remove(0, 1);
            }
            else
            {
                responsebody = Encoding.UTF8.GetString(result);
            }
            var deserialize_object = JsonConvert.DeserializeObject(responsebody);
            JObject jo = JObject.Parse(deserialize_object.ToString());
            JToken jt_total = jo.SelectToken("$.iTotalRecords");
            if (jt_total.ToString() != "0")
            {
                bool _is_found = false;
                for (int i = 0; i < Convert.ToInt32(jt_total) ; i++)
                {
                    JToken jt_detect = jo.SelectToken("$.aaData[" + i + "][0]");
                    string username = Regex.Match(jt_detect.ToString(), "username=\\\"(.*?)\\\"").Groups[1].Value;
                    if (username == player)
                    {
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
                                    break;
                                }
                            }
                        }
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

                                try
                                {
                                    dataGridView_player.Rows[Convert.ToInt32(_players_inner[0]) + 1].Cells[2].Value = "Ongoing";
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

                            try
                            {
                                dataGridView_player.Rows[Convert.ToInt32(_players_inner[0]) + 1].Cells[2].Value = "Ongoing";
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
    }
}
