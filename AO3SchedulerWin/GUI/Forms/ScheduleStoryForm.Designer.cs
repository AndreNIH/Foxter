﻿namespace AO3SchedulerWin.Forms
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
            worksComboBox = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            richTextBox2 = new RichTextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            mainContainer = new TabControl();
            loadingTab = new TabPage();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            chapterDetailsTab = new TabPage();
            button1 = new Button();
            tabPage3 = new TabPage();
            richTextBox3 = new RichTextBox();
            mainContainer.SuspendLayout();
            loadingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            chapterDetailsTab.SuspendLayout();
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
            // worksComboBox
            // 
            worksComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            worksComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            worksComboBox.FormattingEnabled = true;
            worksComboBox.Location = new Point(107, 15);
            worksComboBox.Name = "worksComboBox";
            worksComboBox.Size = new Size(316, 23);
            worksComboBox.TabIndex = 1;
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
            // mainContainer
            // 
            mainContainer.Controls.Add(loadingTab);
            mainContainer.Controls.Add(chapterDetailsTab);
            mainContainer.Controls.Add(tabPage3);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Name = "mainContainer";
            mainContainer.SelectedIndex = 0;
            mainContainer.Size = new Size(439, 559);
            mainContainer.TabIndex = 10;
            // 
            // loadingTab
            // 
            loadingTab.BackColor = Color.White;
            loadingTab.Controls.Add(label5);
            loadingTab.Controls.Add(pictureBox1);
            loadingTab.Location = new Point(4, 24);
            loadingTab.Name = "loadingTab";
            loadingTab.Padding = new Padding(3);
            loadingTab.Size = new Size(431, 531);
            loadingTab.TabIndex = 1;
            loadingTab.Text = "tabPage2";
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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // chapterDetailsTab
            // 
            chapterDetailsTab.Controls.Add(button1);
            chapterDetailsTab.Controls.Add(checkBox2);
            chapterDetailsTab.Controls.Add(worksComboBox);
            chapterDetailsTab.Controls.Add(checkBox1);
            chapterDetailsTab.Controls.Add(label1);
            chapterDetailsTab.Controls.Add(label4);
            chapterDetailsTab.Controls.Add(dateTimePicker1);
            chapterDetailsTab.Controls.Add(richTextBox2);
            chapterDetailsTab.Controls.Add(label2);
            chapterDetailsTab.Controls.Add(label3);
            chapterDetailsTab.Controls.Add(richTextBox1);
            chapterDetailsTab.Location = new Point(4, 24);
            chapterDetailsTab.Name = "chapterDetailsTab";
            chapterDetailsTab.Padding = new Padding(3);
            chapterDetailsTab.Size = new Size(431, 531);
            chapterDetailsTab.TabIndex = 0;
            chapterDetailsTab.Text = "tabPage1";
            chapterDetailsTab.UseVisualStyleBackColor = true;
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
            // tabPage3
            // 
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(431, 531);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.Dock = DockStyle.Fill;
            richTextBox3.Location = new Point(2, 2);
            richTextBox3.Margin = new Padding(2);
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
            Controls.Add(mainContainer);
            Name = "ScheduleStoryForm";
            Text = "Upload New Chapter";
            Load += ScheduleStoryForm_Load;
            mainContainer.ResumeLayout(false);
            loadingTab.ResumeLayout(false);
            loadingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            chapterDetailsTab.ResumeLayout(false);
            chapterDetailsTab.PerformLayout();
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox worksComboBox;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label3;
        private Label label4;
        private RichTextBox richTextBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TabControl mainContainer;
        private TabPage loadingTab;
        private TabPage chapterDetailsTab;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label5;
        private TabPage tabPage3;
        private RichTextBox richTextBox3;
    }
}