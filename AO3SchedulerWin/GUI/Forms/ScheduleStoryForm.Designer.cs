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
            mainContainer = new TabControl();
            loadingTab = new TabPage();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            chapterDetailsTab = new TabPage();
            openInAo3Button = new Button();
            chapterComboBox = new ComboBox();
            deleteButton = new Button();
            label8 = new Label();
            scheduleButton = new Button();
            mainContainer.SuspendLayout();
            loadingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            chapterDetailsTab.SuspendLayout();
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
            // mainContainer
            // 
            mainContainer.Controls.Add(loadingTab);
            mainContainer.Controls.Add(chapterDetailsTab);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Margin = new Padding(4, 5, 4, 5);
            mainContainer.Name = "mainContainer";
            mainContainer.SelectedIndex = 0;
            mainContainer.Size = new Size(627, 640);
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
            loadingTab.Size = new Size(619, 602);
            loadingTab.TabIndex = 1;
            loadingTab.Text = "tabPage1";
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
            pictureBox1.Location = new Point(174, 112);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(277, 340);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // chapterDetailsTab
            // 
            chapterDetailsTab.Controls.Add(openInAo3Button);
            chapterDetailsTab.Controls.Add(chapterComboBox);
            chapterDetailsTab.Controls.Add(deleteButton);
            chapterDetailsTab.Controls.Add(label8);
            chapterDetailsTab.Controls.Add(scheduleButton);
            chapterDetailsTab.Controls.Add(worksComboBox);
            chapterDetailsTab.Controls.Add(label1);
            chapterDetailsTab.Controls.Add(publishingDatePicker);
            chapterDetailsTab.Controls.Add(label2);
            chapterDetailsTab.Location = new Point(4, 34);
            chapterDetailsTab.Margin = new Padding(4, 5, 4, 5);
            chapterDetailsTab.Name = "chapterDetailsTab";
            chapterDetailsTab.Padding = new Padding(4, 5, 4, 5);
            chapterDetailsTab.Size = new Size(619, 602);
            chapterDetailsTab.TabIndex = 0;
            chapterDetailsTab.Text = "tabPage2";
            chapterDetailsTab.UseVisualStyleBackColor = true;
            // 
            // openInAo3Button
            // 
            openInAo3Button.Location = new Point(14, 185);
            openInAo3Button.Margin = new Padding(4, 5, 4, 5);
            openInAo3Button.Name = "openInAo3Button";
            openInAo3Button.Size = new Size(590, 77);
            openInAo3Button.TabIndex = 11;
            openInAo3Button.Text = "Open in Archive of Our Own";
            openInAo3Button.UseVisualStyleBackColor = true;
            // 
            // chapterComboBox
            // 
            chapterComboBox.FormattingEnabled = true;
            chapterComboBox.Location = new Point(153, 70);
            chapterComboBox.Margin = new Padding(4, 5, 4, 5);
            chapterComboBox.Name = "chapterComboBox";
            chapterComboBox.Size = new Size(450, 33);
            chapterComboBox.TabIndex = 14;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deleteButton.Location = new Point(44, 420);
            deleteButton.Margin = new Padding(4, 5, 4, 5);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(539, 75);
            deleteButton.TabIndex = 13;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 77);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(129, 25);
            label8.TabIndex = 11;
            label8.Text = "Select Chapter:";
            // 
            // scheduleButton
            // 
            scheduleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scheduleButton.BackColor = Color.FromArgb(153, 0, 0);
            scheduleButton.ForeColor = Color.White;
            scheduleButton.Location = new Point(44, 505);
            scheduleButton.Margin = new Padding(4, 5, 4, 5);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(539, 75);
            scheduleButton.TabIndex = 10;
            scheduleButton.Text = "Schedule Post";
            scheduleButton.UseVisualStyleBackColor = false;
            scheduleButton.Click += scheduleButton_Click;
            // 
            // ScheduleStoryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 640);
            Controls.Add(mainContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ScheduleStoryForm";
            Text = "Upload New Chapter";
            Load += ScheduleStoryForm_Load;
            mainContainer.ResumeLayout(false);
            loadingTab.ResumeLayout(false);
            loadingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            chapterDetailsTab.ResumeLayout(false);
            chapterDetailsTab.PerformLayout();
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
        private TabControl mainContainer;
        private TabPage loadingTab;
        private TabPage chapterDetailsTab;
        private Button detailsNextButton;
        private PictureBox pictureBox1;
        private Label label5;
        private TabPage convertionTab;
        private Button backConverterButton;
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
        private Button selectFileButton;
        private TextBox filePathTextbox;
        private Label label7;
        private Label label8;
        private Button deleteButton;
        private OpenFileDialog openFileDialog;
        private TabPage finalTab;
        private TextBox storyHtmlTextbox;
        private Button schedulePostButton;
        private Button backFinalButton;
        private ComboBox chapterComboBox;
        private Button scheduleButton;
        private Button openInAo3Button;
    }
}