namespace Inspector
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.panel_header = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_header = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_title = new System.Windows.Forms.Label();
            this.pictureBox_minimize = new System.Windows.Forms.PictureBox();
            this.pictureBox_close = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer_landing = new System.Windows.Forms.Timer(this.components);
            this.panel_landing = new System.Windows.Forms.Panel();
            this.pictureBox_landing = new System.Windows.Forms.PictureBox();
            this.timer_flush_memory = new System.Windows.Forms.Timer(this.components);
            this.timer_detect_running = new System.Windows.Forms.Timer(this.components);
            this.timer_dialog = new System.Windows.Forms.Timer(this.components);
            this.timer_auto_reject = new System.Windows.Forms.Timer(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel_start = new System.Windows.Forms.Panel();
            this.label_timer_count = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label_start_fy = new System.Windows.Forms.Label();
            this.label_end_fy = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.richTextBox_players = new System.Windows.Forms.RichTextBox();
            this.label_select_player = new System.Windows.Forms.Label();
            this.radioButton_tf = new System.Windows.Forms.RadioButton();
            this.radioButton_fy = new System.Windows.Forms.RadioButton();
            this.label_select_brand = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.timer_start = new System.Windows.Forms.Timer(this.components);
            this.panel_status = new System.Windows.Forms.Panel();
            this.dataGridView_player = new System.Windows.Forms.DataGridView();
            this.label_player = new System.Windows.Forms.Label();
            this.label_player_01 = new System.Windows.Forms.Label();
            this.pictureBox_loader = new System.Windows.Forms.PictureBox();
            this.label_total_betrecord = new System.Windows.Forms.Label();
            this.label_gp_count = new System.Windows.Forms.Label();
            this.label_gp_count_01 = new System.Windows.Forms.Label();
            this.label_gp_name = new System.Windows.Forms.Label();
            this.label_gp_name_01 = new System.Windows.Forms.Label();
            this.label_currentrecord = new System.Windows.Forms.Label();
            this.label_page_count = new System.Windows.Forms.Label();
            this.label_page_count_01 = new System.Windows.Forms.Label();
            this.label_currentrecord_01 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).BeginInit();
            this.panel_landing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_landing)).BeginInit();
            this.panel_start.SuspendLayout();
            this.panel_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loader)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(90)))), ((int)(((byte)(101)))));
            this.panel_header.Controls.Add(this.button2);
            this.panel_header.Controls.Add(this.button1);
            this.panel_header.Controls.Add(this.pictureBox_header);
            this.panel_header.Controls.Add(this.panel1);
            this.panel_header.Controls.Add(this.label_title);
            this.panel_header.Controls.Add(this.pictureBox_minimize);
            this.panel_header.Controls.Add(this.pictureBox_close);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(923, 45);
            this.panel_header.TabIndex = 1;
            this.panel_header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_header_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 64;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_header
            // 
            this.pictureBox_header.Image = global::Inspector.Properties.Resources.header;
            this.pictureBox_header.Location = new System.Drawing.Point(21, 12);
            this.pictureBox_header.Name = "pictureBox_header";
            this.pictureBox_header.Size = new System.Drawing.Size(28, 24);
            this.pictureBox_header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_header.TabIndex = 1;
            this.pictureBox_header.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 10);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_title.Location = new System.Drawing.Point(48, 7);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(234, 34);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Inspector";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_title_MouseDown);
            // 
            // pictureBox_minimize
            // 
            this.pictureBox_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_minimize.Image = global::Inspector.Properties.Resources.minus;
            this.pictureBox_minimize.Location = new System.Drawing.Point(378, 10);
            this.pictureBox_minimize.Name = "pictureBox_minimize";
            this.pictureBox_minimize.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_minimize.TabIndex = 1;
            this.pictureBox_minimize.TabStop = false;
            this.pictureBox_minimize.Click += new System.EventHandler(this.pictureBox_minimize_Click);
            // 
            // pictureBox_close
            // 
            this.pictureBox_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_close.Image = global::Inspector.Properties.Resources.close;
            this.pictureBox_close.Location = new System.Drawing.Point(416, 10);
            this.pictureBox_close.Name = "pictureBox_close";
            this.pictureBox_close.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_close.TabIndex = 0;
            this.pictureBox_close.TabStop = false;
            this.pictureBox_close.Click += new System.EventHandler(this.pictureBox_close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(309, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 10);
            this.panel2.TabIndex = 5;
            this.panel2.TabStop = true;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // timer_landing
            // 
            this.timer_landing.Interval = 2000;
            this.timer_landing.Tick += new System.EventHandler(this.timer_landing_Tick);
            // 
            // panel_landing
            // 
            this.panel_landing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(90)))), ((int)(((byte)(101)))));
            this.panel_landing.Controls.Add(this.pictureBox_landing);
            this.panel_landing.Location = new System.Drawing.Point(29, 476);
            this.panel_landing.Name = "panel_landing";
            this.panel_landing.Size = new System.Drawing.Size(468, 457);
            this.panel_landing.TabIndex = 0;
            this.panel_landing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_landing_MouseDown);
            // 
            // pictureBox_landing
            // 
            this.pictureBox_landing.ErrorImage = null;
            this.pictureBox_landing.Image = global::Inspector.Properties.Resources.landing;
            this.pictureBox_landing.Location = new System.Drawing.Point(183, 169);
            this.pictureBox_landing.Name = "pictureBox_landing";
            this.pictureBox_landing.Size = new System.Drawing.Size(111, 113);
            this.pictureBox_landing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_landing.TabIndex = 0;
            this.pictureBox_landing.TabStop = false;
            this.pictureBox_landing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_landing_MouseDown);
            // 
            // timer_flush_memory
            // 
            this.timer_flush_memory.Enabled = true;
            this.timer_flush_memory.Interval = 60000;
            this.timer_flush_memory.Tick += new System.EventHandler(this.timer_flush_memory_Tick);
            // 
            // timer_dialog
            // 
            this.timer_dialog.Interval = 10000;
            this.timer_dialog.Tick += new System.EventHandler(this.timer_dialog_Tick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(-100, 203);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel_start
            // 
            this.panel_start.Controls.Add(this.label_timer_count);
            this.panel_start.Controls.Add(this.dateTimePicker_end);
            this.panel_start.Controls.Add(this.dateTimePicker_start);
            this.panel_start.Controls.Add(this.label_start_fy);
            this.panel_start.Controls.Add(this.label_end_fy);
            this.panel_start.Controls.Add(this.button_start);
            this.panel_start.Controls.Add(this.richTextBox_players);
            this.panel_start.Controls.Add(this.label_select_player);
            this.panel_start.Controls.Add(this.radioButton_tf);
            this.panel_start.Controls.Add(this.radioButton_fy);
            this.panel_start.Controls.Add(this.label_select_brand);
            this.panel_start.Location = new System.Drawing.Point(12, 53);
            this.panel_start.Name = "panel_start";
            this.panel_start.Size = new System.Drawing.Size(443, 178);
            this.panel_start.TabIndex = 13;
            // 
            // label_timer_count
            // 
            this.label_timer_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_count.Location = new System.Drawing.Point(266, 65);
            this.label_timer_count.Name = "label_timer_count";
            this.label_timer_count.Size = new System.Drawing.Size(173, 51);
            this.label_timer_count.TabIndex = 15;
            this.label_timer_count.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_end.Location = new System.Drawing.Point(265, 41);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(175, 21);
            this.dateTimePicker_end.TabIndex = 21;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_start.Location = new System.Drawing.Point(266, 14);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(174, 21);
            this.dateTimePicker_start.TabIndex = 18;
            // 
            // label_start_fy
            // 
            this.label_start_fy.AutoSize = true;
            this.label_start_fy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_start_fy.Location = new System.Drawing.Point(179, 16);
            this.label_start_fy.Name = "label_start_fy";
            this.label_start_fy.Size = new System.Drawing.Size(86, 20);
            this.label_start_fy.TabIndex = 19;
            this.label_start_fy.Text = "Start Time:";
            // 
            // label_end_fy
            // 
            this.label_end_fy.AutoSize = true;
            this.label_end_fy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_end_fy.Location = new System.Drawing.Point(179, 42);
            this.label_end_fy.Name = "label_end_fy";
            this.label_end_fy.Size = new System.Drawing.Size(80, 20);
            this.label_end_fy.TabIndex = 20;
            this.label_end_fy.Text = "End Time:";
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.White;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.Black;
            this.button_start.Location = new System.Drawing.Point(265, 119);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(174, 37);
            this.button_start.TabIndex = 17;
            this.button_start.Text = "SEE MAGIC!";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // richTextBox_players
            // 
            this.richTextBox_players.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.richTextBox_players.Location = new System.Drawing.Point(70, 43);
            this.richTextBox_players.Name = "richTextBox_players";
            this.richTextBox_players.Size = new System.Drawing.Size(90, 113);
            this.richTextBox_players.TabIndex = 16;
            this.richTextBox_players.Text = "";
            this.richTextBox_players.MouseEnter += new System.EventHandler(this.richTextBox_players_MouseEnter);
            // 
            // label_select_player
            // 
            this.label_select_player.AutoSize = true;
            this.label_select_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_select_player.Location = new System.Drawing.Point(1, 41);
            this.label_select_player.Name = "label_select_player";
            this.label_select_player.Size = new System.Drawing.Size(68, 20);
            this.label_select_player.TabIndex = 15;
            this.label_select_player.Text = "Player/s:";
            // 
            // radioButton_tf
            // 
            this.radioButton_tf.AutoSize = true;
            this.radioButton_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_tf.Location = new System.Drawing.Point(121, 16);
            this.radioButton_tf.Name = "radioButton_tf";
            this.radioButton_tf.Size = new System.Drawing.Size(39, 19);
            this.radioButton_tf.TabIndex = 14;
            this.radioButton_tf.Text = "TF";
            this.radioButton_tf.UseVisualStyleBackColor = true;
            this.radioButton_tf.CheckedChanged += new System.EventHandler(this.radioButton_tf_CheckedChanged);
            // 
            // radioButton_fy
            // 
            this.radioButton_fy.AutoSize = true;
            this.radioButton_fy.Checked = true;
            this.radioButton_fy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_fy.Location = new System.Drawing.Point(70, 16);
            this.radioButton_fy.Name = "radioButton_fy";
            this.radioButton_fy.Size = new System.Drawing.Size(39, 19);
            this.radioButton_fy.TabIndex = 13;
            this.radioButton_fy.TabStop = true;
            this.radioButton_fy.Text = "FY";
            this.radioButton_fy.UseVisualStyleBackColor = true;
            this.radioButton_fy.CheckedChanged += new System.EventHandler(this.radioButton_fy_CheckedChanged);
            // 
            // label_select_brand
            // 
            this.label_select_brand.AutoSize = true;
            this.label_select_brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_select_brand.Location = new System.Drawing.Point(0, 14);
            this.label_select_brand.Name = "label_select_brand";
            this.label_select_brand.Size = new System.Drawing.Size(56, 20);
            this.label_select_brand.TabIndex = 12;
            this.label_select_brand.Text = "Brand:";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(11, 51);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(445, 402);
            this.webBrowser.TabIndex = 14;
            this.webBrowser.Visible = false;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // timer_start
            // 
            this.timer_start.Interval = 1000;
            this.timer_start.Tick += new System.EventHandler(this.timer_start_Tick);
            // 
            // panel_status
            // 
            this.panel_status.Controls.Add(this.dataGridView_player);
            this.panel_status.Controls.Add(this.label_player);
            this.panel_status.Controls.Add(this.label_player_01);
            this.panel_status.Controls.Add(this.pictureBox_loader);
            this.panel_status.Controls.Add(this.label_total_betrecord);
            this.panel_status.Controls.Add(this.label_gp_count);
            this.panel_status.Controls.Add(this.label_gp_count_01);
            this.panel_status.Controls.Add(this.label_gp_name);
            this.panel_status.Controls.Add(this.label_gp_name_01);
            this.panel_status.Controls.Add(this.label_currentrecord);
            this.panel_status.Controls.Add(this.label_page_count);
            this.panel_status.Controls.Add(this.label_page_count_01);
            this.panel_status.Controls.Add(this.label_currentrecord_01);
            this.panel_status.Location = new System.Drawing.Point(462, 53);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(449, 403);
            this.panel_status.TabIndex = 51;
            // 
            // dataGridView_player
            // 
            this.dataGridView_player.AllowUserToAddRows = false;
            this.dataGridView_player.AllowUserToDeleteRows = false;
            this.dataGridView_player.AllowUserToResizeColumns = false;
            this.dataGridView_player.AllowUserToResizeRows = false;
            this.dataGridView_player.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_player.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_player.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_player.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_player.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_player.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.player,
            this.status});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_player.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_player.Location = new System.Drawing.Point(56, 274);
            this.dataGridView_player.MultiSelect = false;
            this.dataGridView_player.Name = "dataGridView_player";
            this.dataGridView_player.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_player.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_player.RowHeadersVisible = false;
            this.dataGridView_player.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_player.Size = new System.Drawing.Size(339, 105);
            this.dataGridView_player.TabIndex = 64;
            // 
            // label_player
            // 
            this.label_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player.Location = new System.Drawing.Point(234, 89);
            this.label_player.Name = "label_player";
            this.label_player.Size = new System.Drawing.Size(162, 18);
            this.label_player.TabIndex = 62;
            this.label_player.Text = "-";
            // 
            // label_player_01
            // 
            this.label_player_01.AutoSize = true;
            this.label_player_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player_01.Location = new System.Drawing.Point(166, 89);
            this.label_player_01.Name = "label_player_01";
            this.label_player_01.Size = new System.Drawing.Size(53, 18);
            this.label_player_01.TabIndex = 61;
            this.label_player_01.Text = "Player:";
            // 
            // pictureBox_loader
            // 
            this.pictureBox_loader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_loader.Image = global::Inspector.Properties.Resources.loader;
            this.pictureBox_loader.Location = new System.Drawing.Point(144, 2);
            this.pictureBox_loader.Name = "pictureBox_loader";
            this.pictureBox_loader.Size = new System.Drawing.Size(160, 74);
            this.pictureBox_loader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_loader.TabIndex = 60;
            this.pictureBox_loader.TabStop = false;
            // 
            // label_total_betrecord
            // 
            this.label_total_betrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_total_betrecord.Location = new System.Drawing.Point(233, 242);
            this.label_total_betrecord.Name = "label_total_betrecord";
            this.label_total_betrecord.Size = new System.Drawing.Size(163, 18);
            this.label_total_betrecord.TabIndex = 59;
            this.label_total_betrecord.Text = "-";
            // 
            // label_gp_count
            // 
            this.label_gp_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gp_count.Location = new System.Drawing.Point(233, 212);
            this.label_gp_count.Name = "label_gp_count";
            this.label_gp_count.Size = new System.Drawing.Size(163, 18);
            this.label_gp_count.TabIndex = 57;
            this.label_gp_count.Text = "-";
            // 
            // label_gp_count_01
            // 
            this.label_gp_count_01.AutoSize = true;
            this.label_gp_count_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gp_count_01.Location = new System.Drawing.Point(141, 212);
            this.label_gp_count_01.Name = "label_gp_count_01";
            this.label_gp_count_01.Size = new System.Drawing.Size(78, 18);
            this.label_gp_count_01.TabIndex = 58;
            this.label_gp_count_01.Text = "GP Count:";
            // 
            // label_gp_name
            // 
            this.label_gp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gp_name.Location = new System.Drawing.Point(233, 181);
            this.label_gp_name.Name = "label_gp_name";
            this.label_gp_name.Size = new System.Drawing.Size(163, 18);
            this.label_gp_name.TabIndex = 55;
            this.label_gp_name.Text = "-";
            // 
            // label_gp_name_01
            // 
            this.label_gp_name_01.AutoSize = true;
            this.label_gp_name_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gp_name_01.Location = new System.Drawing.Point(141, 181);
            this.label_gp_name_01.Name = "label_gp_name_01";
            this.label_gp_name_01.Size = new System.Drawing.Size(78, 18);
            this.label_gp_name_01.TabIndex = 56;
            this.label_gp_name_01.Text = "GP Name:";
            // 
            // label_currentrecord
            // 
            this.label_currentrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentrecord.Location = new System.Drawing.Point(233, 150);
            this.label_currentrecord.Name = "label_currentrecord";
            this.label_currentrecord.Size = new System.Drawing.Size(163, 18);
            this.label_currentrecord.TabIndex = 51;
            this.label_currentrecord.Text = "-";
            // 
            // label_page_count
            // 
            this.label_page_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_page_count.Location = new System.Drawing.Point(234, 120);
            this.label_page_count.Name = "label_page_count";
            this.label_page_count.Size = new System.Drawing.Size(162, 18);
            this.label_page_count.TabIndex = 52;
            this.label_page_count.Text = "-";
            // 
            // label_page_count_01
            // 
            this.label_page_count_01.AutoSize = true;
            this.label_page_count_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_page_count_01.Location = new System.Drawing.Point(173, 120);
            this.label_page_count_01.Name = "label_page_count_01";
            this.label_page_count_01.Size = new System.Drawing.Size(46, 18);
            this.label_page_count_01.TabIndex = 54;
            this.label_page_count_01.Text = "Page:";
            // 
            // label_currentrecord_01
            // 
            this.label_currentrecord_01.AutoSize = true;
            this.label_currentrecord_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentrecord_01.Location = new System.Drawing.Point(121, 150);
            this.label_currentrecord_01.Name = "label_currentrecord_01";
            this.label_currentrecord_01.Size = new System.Drawing.Size(98, 18);
            this.label_currentrecord_01.TabIndex = 53;
            this.label_currentrecord_01.Text = "Total Record:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // status
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle3;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // player
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.player.DefaultCellStyle = dataGridViewCellStyle2;
            this.player.HeaderText = "Player";
            this.player.Name = "player";
            this.player.ReadOnly = true;
            this.player.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(923, 468);
            this.Controls.Add(this.panel_status);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_landing);
            this.Controls.Add(this.panel_start);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.webBrowser);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).EndInit();
            this.panel_landing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_landing)).EndInit();
            this.panel_start.ResumeLayout(false);
            this.panel_start.PerformLayout();
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.PictureBox pictureBox_minimize;
        private System.Windows.Forms.PictureBox pictureBox_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer_landing;
        private System.Windows.Forms.PictureBox pictureBox_header;
        private System.Windows.Forms.Panel panel_landing;
        private System.Windows.Forms.PictureBox pictureBox_landing;
        private System.Windows.Forms.Timer timer_flush_memory;
        private System.Windows.Forms.Timer timer_detect_running;
        private System.Windows.Forms.Timer timer_dialog;
        private System.Windows.Forms.Timer timer_auto_reject;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel_start;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.RichTextBox richTextBox_players;
        private System.Windows.Forms.Label label_select_player;
        private System.Windows.Forms.RadioButton radioButton_tf;
        private System.Windows.Forms.RadioButton radioButton_fy;
        private System.Windows.Forms.Label label_select_brand;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label_start_fy;
        private System.Windows.Forms.Label label_end_fy;
        private System.Windows.Forms.Timer timer_start;
        private System.Windows.Forms.Label label_timer_count;
        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.PictureBox pictureBox_loader;
        private System.Windows.Forms.Label label_total_betrecord;
        private System.Windows.Forms.Label label_gp_count;
        private System.Windows.Forms.Label label_gp_count_01;
        private System.Windows.Forms.Label label_gp_name;
        private System.Windows.Forms.Label label_gp_name_01;
        private System.Windows.Forms.Label label_currentrecord;
        private System.Windows.Forms.Label label_page_count;
        private System.Windows.Forms.Label label_page_count_01;
        private System.Windows.Forms.Label label_currentrecord_01;
        private System.Windows.Forms.Label label_player;
        private System.Windows.Forms.Label label_player_01;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView_player;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn player;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}
