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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.panel_header = new System.Windows.Forms.Panel();
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
            this.button_start = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label_select_player = new System.Windows.Forms.Label();
            this.radioButton_tf = new System.Windows.Forms.RadioButton();
            this.radioButton_fy = new System.Windows.Forms.RadioButton();
            this.label_select_brand = new System.Windows.Forms.Label();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).BeginInit();
            this.panel_landing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_landing)).BeginInit();
            this.panel_start.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(90)))), ((int)(((byte)(101)))));
            this.panel_header.Controls.Add(this.pictureBox_header);
            this.panel_header.Controls.Add(this.panel1);
            this.panel_header.Controls.Add(this.label_title);
            this.panel_header.Controls.Add(this.pictureBox_minimize);
            this.panel_header.Controls.Add(this.pictureBox_close);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(466, 45);
            this.panel_header.TabIndex = 1;
            this.panel_header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_header_MouseDown);
            // 
            // pictureBox_header
            // 
            this.pictureBox_header.Image = global::Inspector.Properties.Resources.header;
            this.pictureBox_header.Location = new System.Drawing.Point(21, 10);
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
            this.label_title.Location = new System.Drawing.Point(51, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(234, 45);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Inspector";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_title_MouseDown);
            // 
            // pictureBox_minimize
            // 
            this.pictureBox_minimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.pictureBox_close.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.panel_landing.Location = new System.Drawing.Point(0, 10);
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
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(-100, 203);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel_start
            // 
            this.panel_start.Controls.Add(this.button_start);
            this.panel_start.Controls.Add(this.richTextBox1);
            this.panel_start.Controls.Add(this.label_select_player);
            this.panel_start.Controls.Add(this.radioButton_tf);
            this.panel_start.Controls.Add(this.radioButton_fy);
            this.panel_start.Controls.Add(this.label_select_brand);
            this.panel_start.Location = new System.Drawing.Point(12, 53);
            this.panel_start.Name = "panel_start";
            this.panel_start.Size = new System.Drawing.Size(442, 178);
            this.panel_start.TabIndex = 13;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.White;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.Black;
            this.button_start.Location = new System.Drawing.Point(313, 49);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(118, 53);
            this.button_start.TabIndex = 17;
            this.button_start.Text = "SEE MAGIC!";
            this.button_start.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.richTextBox1.Location = new System.Drawing.Point(90, 51);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(134, 113);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // label_select_player
            // 
            this.label_select_player.AutoSize = true;
            this.label_select_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_select_player.Location = new System.Drawing.Point(13, 49);
            this.label_select_player.Name = "label_select_player";
            this.label_select_player.Size = new System.Drawing.Size(68, 20);
            this.label_select_player.TabIndex = 15;
            this.label_select_player.Text = "Player/s:";
            // 
            // radioButton_tf
            // 
            this.radioButton_tf.AutoSize = true;
            this.radioButton_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_tf.Location = new System.Drawing.Point(141, 16);
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
            this.radioButton_fy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_fy.Location = new System.Drawing.Point(90, 16);
            this.radioButton_fy.Name = "radioButton_fy";
            this.radioButton_fy.Size = new System.Drawing.Size(39, 19);
            this.radioButton_fy.TabIndex = 13;
            this.radioButton_fy.Text = "FY";
            this.radioButton_fy.UseVisualStyleBackColor = true;
            this.radioButton_fy.CheckedChanged += new System.EventHandler(this.radioButton_fy_CheckedChanged);
            // 
            // label_select_brand
            // 
            this.label_select_brand.AutoSize = true;
            this.label_select_brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_select_brand.Location = new System.Drawing.Point(12, 14);
            this.label_select_brand.Name = "label_select_brand";
            this.label_select_brand.Size = new System.Drawing.Size(56, 20);
            this.label_select_brand.TabIndex = 12;
            this.label_select_brand.Text = "Brand:";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(466, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_landing);
            this.Controls.Add(this.panel_start);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.panel_header);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(466, 468);
            this.MinimumSize = new System.Drawing.Size(466, 168);
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label_select_player;
        private System.Windows.Forms.RadioButton radioButton_tf;
        private System.Windows.Forms.RadioButton radioButton_fy;
        private System.Windows.Forms.Label label_select_brand;
    }
}
