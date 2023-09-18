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
            worksComboBox = new ComboBox();
            publishingDatePicker = new DateTimePicker();
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
            detailsNextButton = new Button();
            tabPage3 = new TabPage();
            button3 = new Button();
            convertFixNextButton = new Button();
            label6 = new Label();
            groupBox2 = new GroupBox();
            checkBox8 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            groupBox1 = new GroupBox();
            button4 = new Button();
            textBox1 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            chapterTitleTextbox = new TextBox();
            mainContainer.SuspendLayout();
            loadingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            chapterDetailsTab.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 19);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Select Story:";
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
            // publishingDatePicker
            // 
            publishingDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            publishingDatePicker.CustomFormat = "dd MMM yy hh:mm tt";
            publishingDatePicker.Format = DateTimePickerFormat.Custom;
            publishingDatePicker.Location = new Point(107, 71);
            publishingDatePicker.Name = "publishingDatePicker";
            publishingDatePicker.Size = new Size(316, 23);
            publishingDatePicker.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 75);
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
            chapterDetailsTab.Controls.Add(chapterTitleTextbox);
            chapterDetailsTab.Controls.Add(label8);
            chapterDetailsTab.Controls.Add(detailsNextButton);
            chapterDetailsTab.Controls.Add(checkBox2);
            chapterDetailsTab.Controls.Add(worksComboBox);
            chapterDetailsTab.Controls.Add(checkBox1);
            chapterDetailsTab.Controls.Add(label1);
            chapterDetailsTab.Controls.Add(label4);
            chapterDetailsTab.Controls.Add(publishingDatePicker);
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
            // detailsNextButton
            // 
            detailsNextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            detailsNextButton.Location = new Point(31, 478);
            detailsNextButton.Name = "detailsNextButton";
            detailsNextButton.Size = new Size(377, 45);
            detailsNextButton.TabIndex = 10;
            detailsNextButton.Text = "Next";
            detailsNextButton.UseVisualStyleBackColor = true;
            detailsNextButton.Click += detailsNextButton_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(convertFixNextButton);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(431, 531);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(31, 427);
            button3.Name = "button3";
            button3.Size = new Size(377, 45);
            button3.TabIndex = 13;
            button3.Text = "Back";
            button3.UseVisualStyleBackColor = true;
            // 
            // convertFixNextButton
            // 
            convertFixNextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            convertFixNextButton.Location = new Point(31, 478);
            convertFixNextButton.Name = "convertFixNextButton";
            convertFixNextButton.Size = new Size(377, 45);
            convertFixNextButton.TabIndex = 12;
            convertFixNextButton.Text = "Next";
            convertFixNextButton.UseVisualStyleBackColor = true;
            convertFixNextButton.Click += convertFixNextButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 275);
            label6.Name = "label6";
            label6.Size = new Size(350, 15);
            label6.TabIndex = 11;
            label6.Text = "* Document to HTML converter powered by AOYeet (@daemuth)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBox8);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox11);
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Controls.Add(checkBox10);
            groupBox2.Controls.Add(checkBox5);
            groupBox2.Controls.Add(checkBox9);
            groupBox2.Controls.Add(checkBox6);
            groupBox2.Controls.Add(checkBox7);
            groupBox2.Location = new Point(13, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(410, 165);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Options";
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Checked = true;
            checkBox8.CheckState = CheckState.Checked;
            checkBox8.Location = new Point(183, 22);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(154, 19);
            checkBox8.TabIndex = 5;
            checkBox8.Text = "Set Heading Alignments";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(6, 22);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(129, 19);
            checkBox3.TabIndex = 0;
            checkBox3.Text = "Remove comments";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Checked = true;
            checkBox11.CheckState = CheckState.Checked;
            checkBox11.Location = new Point(183, 97);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(119, 19);
            checkBox11.TabIndex = 8;
            checkBox11.Text = "Keep Empty Lines";
            checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Location = new Point(6, 47);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(163, 19);
            checkBox4.TabIndex = 1;
            checkBox4.Text = "Set Paragraph Alignments";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Checked = true;
            checkBox10.CheckState = CheckState.Checked;
            checkBox10.Location = new Point(183, 72);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(143, 19);
            checkBox10.TabIndex = 7;
            checkBox10.Text = "Convert Strikethrough";
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.Location = new Point(6, 72);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(95, 19);
            checkBox5.TabIndex = 2;
            checkBox5.Text = "Convert Bold";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Checked = true;
            checkBox9.CheckState = CheckState.Checked;
            checkBox9.Location = new Point(183, 47);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(96, 19);
            checkBox9.TabIndex = 6;
            checkBox9.Text = "Convert Italic";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Checked = true;
            checkBox6.CheckState = CheckState.Checked;
            checkBox6.Location = new Point(6, 97);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(122, 19);
            checkBox6.TabIndex = 3;
            checkBox6.Text = "Convert Underline";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Checked = true;
            checkBox7.CheckState = CheckState.Checked;
            checkBox7.Location = new Point(6, 122);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(164, 19);
            checkBox7.TabIndex = 4;
            checkBox7.Text = "Remove class declarations";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(13, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 96);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "File";
            // 
            // button4
            // 
            button4.Location = new Point(6, 51);
            button4.Name = "button4";
            button4.Size = new Size(398, 23);
            button4.TabIndex = 2;
            button4.Text = "Select File";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(46, 22);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "C:/Users/Documents/Fanfic.html";
            textBox1.Size = new Size(358, 23);
            textBox1.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 26);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 0;
            label7.Text = "Path:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 46);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 11;
            label8.Text = "Chapter Title:";
            // 
            // chapterTitleTextbox
            // 
            chapterTitleTextbox.Location = new Point(107, 42);
            chapterTitleTextbox.Name = "chapterTitleTextbox";
            chapterTitleTextbox.Size = new Size(316, 23);
            chapterTitleTextbox.TabIndex = 12;
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
            tabPage3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox worksComboBox;
        private DateTimePicker publishingDatePicker;
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
        private Button detailsNextButton;
        private PictureBox pictureBox1;
        private Label label5;
        private TabPage tabPage3;
        private Button button3;
        private Button convertFixNextButton;
        private Label label6;
        private GroupBox groupBox2;
        private CheckBox checkBox8;
        private CheckBox checkBox3;
        private CheckBox checkBox11;
        private CheckBox checkBox4;
        private CheckBox checkBox10;
        private CheckBox checkBox5;
        private CheckBox checkBox9;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private GroupBox groupBox1;
        private Button button4;
        private TextBox textBox1;
        private Label label7;
        private TextBox chapterTitleTextbox;
        private Label label8;
    }
}