namespace Foxter.GUI.Screens
{
    partial class SettingsScreen
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
            groupBox2 = new GroupBox();
            remotePublishRadio = new RadioButton();
            localPublishRadio = new RadioButton();
            groupBox1 = new GroupBox();
            sendToTrayCheckbox = new CheckBox();
            startMinimizedCheckbox = new CheckBox();
            runAtStartupCheckbox = new CheckBox();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(remotePublishRadio);
            groupBox2.Controls.Add(localPublishRadio);
            groupBox2.Location = new Point(438, 12);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(419, 262);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Publish Mode";
            // 
            // remotePublishRadio
            // 
            remotePublishRadio.AutoSize = true;
            remotePublishRadio.Enabled = false;
            remotePublishRadio.Location = new Point(9, 158);
            remotePublishRadio.Margin = new Padding(4, 5, 4, 5);
            remotePublishRadio.Name = "remotePublishRadio";
            remotePublishRadio.Size = new Size(266, 29);
            remotePublishRadio.TabIndex = 6;
            remotePublishRadio.Text = "Publish from a remote server";
            remotePublishRadio.UseVisualStyleBackColor = true;
            // 
            // localPublishRadio
            // 
            localPublishRadio.AutoSize = true;
            localPublishRadio.Checked = true;
            localPublishRadio.Location = new Point(9, 117);
            localPublishRadio.Margin = new Padding(4, 5, 4, 5);
            localPublishRadio.Name = "localPublishRadio";
            localPublishRadio.Size = new Size(226, 29);
            localPublishRadio.TabIndex = 6;
            localPublishRadio.TabStop = true;
            localPublishRadio.Text = "Publish from this device";
            localPublishRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(sendToTrayCheckbox);
            groupBox1.Controls.Add(startMinimizedCheckbox);
            groupBox1.Controls.Add(runAtStartupCheckbox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(419, 262);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "General";
            // 
            // sendToTrayCheckbox
            // 
            sendToTrayCheckbox.AutoSize = true;
            sendToTrayCheckbox.Location = new Point(18, 168);
            sendToTrayCheckbox.Name = "sendToTrayCheckbox";
            sendToTrayCheckbox.Size = new Size(206, 29);
            sendToTrayCheckbox.TabIndex = 9;
            sendToTrayCheckbox.Text = "Send to tray on close";
            sendToTrayCheckbox.UseVisualStyleBackColor = true;
            // 
            // startMinimizedCheckbox
            // 
            startMinimizedCheckbox.AutoSize = true;
            startMinimizedCheckbox.Location = new Point(18, 133);
            startMinimizedCheckbox.Name = "startMinimizedCheckbox";
            startMinimizedCheckbox.Size = new Size(161, 29);
            startMinimizedCheckbox.TabIndex = 8;
            startMinimizedCheckbox.Text = "Start minimized";
            startMinimizedCheckbox.UseVisualStyleBackColor = true;
            // 
            // runAtStartupCheckbox
            // 
            runAtStartupCheckbox.AutoSize = true;
            runAtStartupCheckbox.Location = new Point(18, 98);
            runAtStartupCheckbox.Name = "runAtStartupCheckbox";
            runAtStartupCheckbox.Size = new Size(248, 29);
            runAtStartupCheckbox.TabIndex = 7;
            runAtStartupCheckbox.Text = "Run application on startup";
            runAtStartupCheckbox.UseVisualStyleBackColor = true;
            runAtStartupCheckbox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // SettingsScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SettingsScreen";
            Text = "SettingsScreen";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private RadioButton remotePublishRadio;
        private RadioButton localPublishRadio;
        private GroupBox groupBox1;
        private CheckBox runAtStartupCheckbox;
        private CheckBox sendToTrayCheckbox;
        private CheckBox startMinimizedCheckbox;
    }
}