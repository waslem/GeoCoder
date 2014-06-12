namespace GeoCoder
{
    partial class OptionsForm
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
            this.lblEmailResults = new System.Windows.Forms.Label();
            this.txtbxResultsEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxUngeoEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxInHouseCutoffReference = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbxSmtpHost = new System.Windows.Forms.TextBox();
            this.txtbxSmtpPort = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogSave = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxSmtpUser = new System.Windows.Forms.TextBox();
            this.txtBoxSmtpPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblEmailResults
            // 
            this.lblEmailResults.AutoSize = true;
            this.lblEmailResults.Location = new System.Drawing.Point(104, 126);
            this.lblEmailResults.Name = "lblEmailResults";
            this.lblEmailResults.Size = new System.Drawing.Size(114, 13);
            this.lblEmailResults.TabIndex = 0;
            this.lblEmailResults.Text = "Results Email Address:";
            // 
            // txtbxResultsEmail
            // 
            this.txtbxResultsEmail.Location = new System.Drawing.Point(221, 123);
            this.txtbxResultsEmail.Name = "txtbxResultsEmail";
            this.txtbxResultsEmail.Size = new System.Drawing.Size(181, 20);
            this.txtbxResultsEmail.TabIndex = 1;
            this.txtbxResultsEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ungeo Email Address:";
            // 
            // txtbxUngeoEmail
            // 
            this.txtbxUngeoEmail.Location = new System.Drawing.Point(221, 148);
            this.txtbxUngeoEmail.Name = "txtbxUngeoEmail";
            this.txtbxUngeoEmail.Size = new System.Drawing.Size(181, 20);
            this.txtbxUngeoEmail.TabIndex = 3;
            this.txtbxUngeoEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "In-house Collect Reference Cutoff:";
            // 
            // txtbxInHouseCutoffReference
            // 
            this.txtbxInHouseCutoffReference.Location = new System.Drawing.Point(221, 333);
            this.txtbxInHouseCutoffReference.Name = "txtbxInHouseCutoffReference";
            this.txtbxInHouseCutoffReference.Size = new System.Drawing.Size(181, 20);
            this.txtbxInHouseCutoffReference.TabIndex = 5;
            this.txtbxInHouseCutoffReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(246, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Email Options...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Set Default Save Location...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SetDefaultSaveLocation_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Set Default Open Location...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SetDefaultOpenLocation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "File Options...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "System Options...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "SMTP Host:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "SMTP Port:";
            // 
            // txtbxSmtpHost
            // 
            this.txtbxSmtpHost.Location = new System.Drawing.Point(221, 174);
            this.txtbxSmtpHost.Name = "txtbxSmtpHost";
            this.txtbxSmtpHost.Size = new System.Drawing.Size(181, 20);
            this.txtbxSmtpHost.TabIndex = 15;
            this.txtbxSmtpHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbxSmtpPort
            // 
            this.txtbxSmtpPort.Location = new System.Drawing.Point(221, 200);
            this.txtbxSmtpPort.Name = "txtbxSmtpPort";
            this.txtbxSmtpPort.Size = new System.Drawing.Size(181, 20);
            this.txtbxSmtpPort.TabIndex = 16;
            this.txtbxSmtpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Smtp username:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(132, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Smtp Password:";
            // 
            // txtBoxSmtpUser
            // 
            this.txtBoxSmtpUser.Location = new System.Drawing.Point(221, 226);
            this.txtBoxSmtpUser.Name = "txtBoxSmtpUser";
            this.txtBoxSmtpUser.Size = new System.Drawing.Size(178, 20);
            this.txtBoxSmtpUser.TabIndex = 19;
            this.txtBoxSmtpUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxSmtpPass
            // 
            this.txtBoxSmtpPass.Location = new System.Drawing.Point(221, 252);
            this.txtBoxSmtpPass.Name = "txtBoxSmtpPass";
            this.txtBoxSmtpPass.Size = new System.Drawing.Size(178, 20);
            this.txtBoxSmtpPass.TabIndex = 20;
            this.txtBoxSmtpPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBoxSmtpPass.UseSystemPasswordChar = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 422);
            this.Controls.Add(this.txtBoxSmtpPass);
            this.Controls.Add(this.txtBoxSmtpUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtbxSmtpPort);
            this.Controls.Add(this.txtbxSmtpHost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtbxInHouseCutoffReference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbxUngeoEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxResultsEmail);
            this.Controls.Add(this.lblEmailResults);
            this.Name = "OptionsForm";
            this.Text = "Options...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmailResults;
        private System.Windows.Forms.TextBox txtbxResultsEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxUngeoEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxInHouseCutoffReference;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbxSmtpHost;
        private System.Windows.Forms.TextBox txtbxSmtpPort;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOpen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxSmtpUser;
        private System.Windows.Forms.TextBox txtBoxSmtpPass;
    }
}