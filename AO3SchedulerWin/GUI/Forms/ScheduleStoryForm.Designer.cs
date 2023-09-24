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
            chapterSummaryTextbox = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            chapterNotesTextbox = new RichTextBox();
            notesAtStartCheckbox = new CheckBox();
            notesAtEndCheckbox = new CheckBox();
            mainContainer = new TabControl();
            loadingTab = new TabPage();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            chapterDetailsTab = new TabPage();
            chapterTitleTextbox = new TextBox();
            label8 = new Label();
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
            label1.Location = new Point(14, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 0;
            label1.Text = "Select Story:";
            // 
            // worksComboBox
            // 
            worksComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            worksComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            worksComboBox.FormattingEnabled = true;
            worksComboBox.Location = new Point(153, 25);
            worksComboBox.Margin = new Padding(4, 5, 4, 5);
            worksComboBox.Name = "worksComboBox";
            worksComboBox.Size = new Size(450, 33);
            worksComboBox.TabIndex = 1;
            // 
            // publishingDatePicker
            // 
            publishingDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            publishingDatePicker.CustomFormat = "dd MMM yy hh:mm tt";
            publishingDatePicker.Format = DateTimePickerFormat.Custom;
            publishingDatePicker.Location = new Point(153, 118);
            publishingDatePicker.Margin = new Padding(4, 5, 4, 5);
            publishingDatePicker.Name = "publishingDatePicker";
            publishingDatePicker.Size = new Size(450, 31);
            publishingDatePicker.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 125);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 25);
            label2.TabIndex = 3;
            label2.Text = "Publishing Date:";
            // 
            // chapterSummaryTextbox
            // 
            chapterSummaryTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chapterSummaryTextbox.Location = new Point(11, 198);
            chapterSummaryTextbox.Margin = new Padding(4, 5, 4, 5);
            chapterSummaryTextbox.Name = "chapterSummaryTextbox";
            chapterSummaryTextbox.Size = new Size(591, 216);
            chapterSummaryTextbox.TabIndex = 4;
            chapterSummaryTextbox.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 168);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 25);
            label3.TabIndex = 5;
            label3.Text = "Chapter Summary";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 438);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 7;
            label4.Text = "Chapter Notes";
            // 
            // chapterNotesTextbox
            // 
            chapterNotesTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chapterNotesTextbox.Location = new Point(11, 468);
            chapterNotesTextbox.Margin = new Padding(4, 5, 4, 5);
            chapterNotesTextbox.Name = "chapterNotesTextbox";
            chapterNotesTextbox.Size = new Size(591, 216);
            chapterNotesTextbox.TabIndex = 6;
            chapterNotesTextbox.Text = "";
            // 
            // notesAtStartCheckbox
            // 
            notesAtStartCheckbox.AutoSize = true;
            notesAtStartCheckbox.Location = new Point(11, 698);
            notesAtStartCheckbox.Margin = new Padding(4, 5, 4, 5);
            notesAtStartCheckbox.Name = "notesAtStartCheckbox";
            notesAtStartCheckbox.Size = new Size(220, 29);
            notesAtStartCheckbox.TabIndex = 8;
            notesAtStartCheckbox.Text = "Notes at the beginning";
            notesAtStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // notesAtEndCheckbox
            // 
            notesAtEndCheckbox.AutoSize = true;
            notesAtEndCheckbox.Location = new Point(11, 740);
            notesAtEndCheckbox.Margin = new Padding(4, 5, 4, 5);
            notesAtEndCheckbox.Name = "notesAtEndCheckbox";
            notesAtEndCheckbox.Size = new Size(170, 29);
            notesAtEndCheckbox.TabIndex = 9;
            notesAtEndCheckbox.Text = "Notes at the end";
            notesAtEndCheckbox.UseVisualStyleBackColor = true;
            // 
            // mainContainer
            // 
            mainContainer.Controls.Add(loadingTab);
            mainContainer.Controls.Add(chapterDetailsTab);
            mainContainer.Controls.Add(tabPage3);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Margin = new Padding(4, 5, 4, 5);
            mainContainer.Name = "mainContainer";
            mainContainer.SelectedIndex = 0;
            mainContainer.Size = new Size(627, 932);
            mainContainer.TabIndex = 10;
            // 
            // loadingTab
            // 
            loadingTab.BackColor = Color.White;
            loadingTab.Controls.Add(label5);
            loadingTab.Controls.Add(pictureBox1);
            loadingTab.Location = new Point(4, 34);
            loadingTab.Margin = new Padding(4, 5, 4, 5);
            loadingTab.Name = "loadingTab";
            loadingTab.Padding = new Padding(4, 5, 4, 5);
            loadingTab.Size = new Size(619, 894);
            loadingTab.TabIndex = 1;
            loadingTab.Text = "tabPage2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(174, 487);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(290, 44);
            label5.TabIndex = 1;
            label5.Text = "Retrieving works...";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(167, 128);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(293, 340);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // chapterDetailsTab
            // 
            chapterDetailsTab.Controls.Add(chapterTitleTextbox);
            chapterDetailsTab.Controls.Add(label8);
            chapterDetailsTab.Controls.Add(detailsNextButton);
            chapterDetailsTab.Controls.Add(notesAtEndCheckbox);
            chapterDetailsTab.Controls.Add(worksComboBox);
            chapterDetailsTab.Controls.Add(notesAtStartCheckbox);
            chapterDetailsTab.Controls.Add(label1);
            chapterDetailsTab.Controls.Add(label4);
            chapterDetailsTab.Controls.Add(publishingDatePicker);
            chapterDetailsTab.Controls.Add(chapterNotesTextbox);
            chapterDetailsTab.Controls.Add(label2);
            chapterDetailsTab.Controls.Add(label3);
            chapterDetailsTab.Controls.Add(chapterSummaryTextbox);
            chapterDetailsTab.Location = new Point(4, 34);
            chapterDetailsTab.Margin = new Padding(4, 5, 4, 5);
            chapterDetailsTab.Name = "chapterDetailsTab";
            chapterDetailsTab.Padding = new Padding(4, 5, 4, 5);
            chapterDetailsTab.Size = new Size(619, 894);
            chapterDetailsTab.TabIndex = 0;
            chapterDetailsTab.Text = "tabPage1";
            chapterDetailsTab.UseVisualStyleBackColor = true;
            // 
            // chapterTitleTextbox
            // 
            chapterTitleTextbox.Location = new Point(153, 70);
            chapterTitleTextbox.Margin = new Padding(4, 5, 4, 5);
            chapterTitleTextbox.Name = "chapterTitleTextbox";
            chapterTitleTextbox.Size = new Size(450, 31);
            chapterTitleTextbox.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 77);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(115, 25);
            label8.TabIndex = 11;
            label8.Text = "Chapter Title:";
            // 
            // detailsNextButton
            // 
            detailsNextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            detailsNextButton.Location = new Point(44, 797);
            detailsNextButton.Margin = new Padding(4, 5, 4, 5);
            detailsNextButton.Name = "detailsNextButton";
            detailsNextButton.Size = new Size(539, 75);
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
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 3, 3, 3);
            tabPage3.Size = new Size(619, 894);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(44, 712);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(539, 75);
            button3.TabIndex = 13;
            button3.Text = "Back";
            button3.UseVisualStyleBackColor = true;
            // 
            // convertFixNextButton
            // 
            convertFixNextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            convertFixNextButton.Location = new Point(44, 797);
            convertFixNextButton.Margin = new Padding(4, 5, 4, 5);
            convertFixNextButton.Name = "convertFixNextButton";
            convertFixNextButton.Size = new Size(539, 75);
            convertFixNextButton.TabIndex = 12;
            convertFixNextButton.Text = "Next";
            convertFixNextButton.UseVisualStyleBackColor = true;
            convertFixNextButton.Click += convertFixNextButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 458);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(526, 25);
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
            groupBox2.Location = new Point(19, 178);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(586, 275);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Options";
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Checked = true;
            checkBox8.CheckState = CheckState.Checked;
            checkBox8.Location = new Point(261, 37);
            checkBox8.Margin = new Padding(4, 5, 4, 5);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(230, 29);
            checkBox8.TabIndex = 5;
            checkBox8.Text = "Set Heading Alignments";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(9, 37);
            checkBox3.Margin = new Padding(4, 5, 4, 5);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(191, 29);
            checkBox3.TabIndex = 0;
            checkBox3.Text = "Remove comments";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Checked = true;
            checkBox11.CheckState = CheckState.Checked;
            checkBox11.Location = new Point(261, 162);
            checkBox11.Margin = new Padding(4, 5, 4, 5);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(177, 29);
            checkBox11.TabIndex = 8;
            checkBox11.Text = "Keep Empty Lines";
            checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Location = new Point(9, 78);
            checkBox4.Margin = new Padding(4, 5, 4, 5);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(243, 29);
            checkBox4.TabIndex = 1;
            checkBox4.Text = "Set Paragraph Alignments";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Checked = true;
            checkBox10.CheckState = CheckState.Checked;
            checkBox10.Location = new Point(261, 120);
            checkBox10.Margin = new Padding(4, 5, 4, 5);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(212, 29);
            checkBox10.TabIndex = 7;
            checkBox10.Text = "Convert Strikethrough";
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.Location = new Point(9, 120);
            checkBox5.Margin = new Padding(4, 5, 4, 5);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(141, 29);
            checkBox5.TabIndex = 2;
            checkBox5.Text = "Convert Bold";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Checked = true;
            checkBox9.CheckState = CheckState.Checked;
            checkBox9.Location = new Point(261, 78);
            checkBox9.Margin = new Padding(4, 5, 4, 5);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(141, 29);
            checkBox9.TabIndex = 6;
            checkBox9.Text = "Convert Italic";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Checked = true;
            checkBox6.CheckState = CheckState.Checked;
            checkBox6.Location = new Point(9, 162);
            checkBox6.Margin = new Padding(4, 5, 4, 5);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(180, 29);
            checkBox6.TabIndex = 3;
            checkBox6.Text = "Convert Underline";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Checked = true;
            checkBox7.CheckState = CheckState.Checked;
            checkBox7.Location = new Point(9, 203);
            checkBox7.Margin = new Padding(4, 5, 4, 5);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(244, 29);
            checkBox7.TabIndex = 4;
            checkBox7.Text = "Remove class declarations";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(19, 8);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(586, 160);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "File";
            // 
            // button4
            // 
            button4.Location = new Point(9, 85);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(569, 38);
            button4.TabIndex = 2;
            button4.Text = "Select File";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(66, 37);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "C:/Users/Documents/Fanfic.html";
            textBox1.Size = new Size(510, 31);
            textBox1.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 43);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(50, 25);
            label7.TabIndex = 0;
            label7.Text = "Path:";
            // 
            // ScheduleStoryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 932);
            Controls.Add(mainContainer);
            Margin = new Padding(4, 5, 4, 5);
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
        private RichTextBox chapterSummaryTextbox;
        private Label label3;
        private Label label4;
        private RichTextBox chapterNotesTextbox;
        private CheckBox notesAtStartCheckbox;
        private CheckBox notesAtEndCheckbox;
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