namespace AO3SchedulerWin.Forms
{
    partial class ScheduleStoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleStoryForm));
            label1 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            richTextBox2 = new RichTextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            mainContent = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            tabPage2 = new TabPage();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            tabPage3 = new TabPage();
            richTextBox3 = new RichTextBox();
            mainContent.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 18);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Select Story";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(107, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(316, 23);
            comboBox1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker1.CustomFormat = "dd MMM yy hh:mm tt";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(107, 44);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(316, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 50);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Publishing Date:";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(8, 119);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(415, 131);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 101);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 5;
            label3.Text = "Chapter Summary";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 263);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 7;
            label4.Text = "Chapter Notes";
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.Location = new Point(8, 281);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(415, 131);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = "";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(8, 419);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(147, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Notes at the beginning";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(8, 444);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(113, 19);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Notes at the end";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // mainContent
            // 
            mainContent.Controls.Add(tabPage1);
            mainContent.Controls.Add(tabPage2);
            mainContent.Controls.Add(tabPage3);
            mainContent.Dock = DockStyle.Fill;
            mainContent.Location = new Point(0, 0);
            mainContent.Name = "mainContent";
            mainContent.SelectedIndex = 0;
            mainContent.Size = new Size(439, 559);
            mainContent.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(checkBox2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(dateTimePicker1);
            tabPage1.Controls.Add(richTextBox2);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(431, 531);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(31, 478);
            button1.Name = "button1";
            button1.Size = new Size(377, 45);
            button1.TabIndex = 10;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(431, 531);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(122, 292);
            label5.Name = "label5";
            label5.Size = new Size(194, 29);
            label5.TabIndex = 1;
            label5.Text = "Retrieving works...";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(117, 77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 204);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2, 2, 2, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2, 2, 2, 2);
            tabPage3.Size = new Size(431, 531);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.Dock = DockStyle.Fill;
            richTextBox3.Location = new Point(2, 2);
            richTextBox3.Margin = new Padding(2, 2, 2, 2);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(427, 527);
            richTextBox3.TabIndex = 0;
            richTextBox3.Text = "";
            // 
            // ScheduleStoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 559);
            Controls.Add(mainContent);
            Name = "ScheduleStoryForm";
            Text = "ScheduleStoryForm";
            Load += ScheduleStoryForm_Load;
            mainContent.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label3;
        private Label label4;
        private RichTextBox richTextBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TabControl mainContent;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label5;
        private TabPage tabPage3;
        private RichTextBox richTextBox3;
    }
}