namespace GeoCoder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonExport = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDefaultSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDefaultOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLoad = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogCsv = new System.Windows.Forms.SaveFileDialog();
            this.buttonImport = new System.Windows.Forms.Button();
            this.folderBrowserDefaultSave = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDefaultOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.progressExport = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.dataGridViewAddresses = new System.Windows.Forms.DataGridView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelResults = new System.Windows.Forms.Panel();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblGeocoded = new System.Windows.Forms.Label();
            this.lblUngeo = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblGeocdedCount = new System.Windows.Forms.Label();
            this.lblUngeoCount = new System.Windows.Forms.Label();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddresses)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(85, 147);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(144, 54);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Export Results";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuDefaultSave,
            this.toolStripMenuDefaultOpen,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuDefaultSave
            // 
            this.toolStripMenuDefaultSave.Name = "toolStripMenuDefaultSave";
            this.toolStripMenuDefaultSave.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuDefaultSave.Text = "Default Save Location";
            this.toolStripMenuDefaultSave.Click += new System.EventHandler(this.toolStripMenuDefaultSave_Click);
            // 
            // toolStripMenuDefaultOpen
            // 
            this.toolStripMenuDefaultOpen.Name = "toolStripMenuDefaultOpen";
            this.toolStripMenuDefaultOpen.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuDefaultOpen.Text = "Default Open Location";
            this.toolStripMenuDefaultOpen.Click += new System.EventHandler(this.toolStripMenuDefaultOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(190, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileLoad
            // 
            this.openFileLoad.FileName = "openFileLoad";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(85, 74);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(144, 54);
            this.buttonImport.TabIndex = 5;
            this.buttonImport.Text = "Import CSV";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // folderBrowserDefaultSave
            // 
            this.folderBrowserDefaultSave.SelectedPath = "C:\\";
            // 
            // progressExport
            // 
            this.progressExport.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressExport.Location = new System.Drawing.Point(4, 54);
            this.progressExport.Name = "progressExport";
            this.progressExport.Size = new System.Drawing.Size(306, 23);
            this.progressExport.Step = 4;
            this.progressExport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressExport.TabIndex = 6;
            this.progressExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Export Results";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "BBPO CSV Geocoder";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 54);
            this.button2.TabIndex = 5;
            this.button2.Text = "Import CSV";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(37, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 38);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButtons.Controls.Add(this.label2);
            this.panelButtons.Controls.Add(this.pictureBox2);
            this.panelButtons.Controls.Add(this.buttonExport);
            this.panelButtons.Controls.Add(this.button1);
            this.panelButtons.Controls.Add(this.button2);
            this.panelButtons.Controls.Add(this.buttonImport);
            this.panelButtons.Location = new System.Drawing.Point(14, 14);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(316, 224);
            this.panelButtons.TabIndex = 8;
            // 
            // dataGridViewAddresses
            // 
            this.dataGridViewAddresses.AllowUserToAddRows = false;
            this.dataGridViewAddresses.AllowUserToDeleteRows = false;
            this.dataGridViewAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAddresses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddresses.Location = new System.Drawing.Point(350, 14);
            this.dataGridViewAddresses.Name = "dataGridViewAddresses";
            this.dataGridViewAddresses.Size = new System.Drawing.Size(571, 482);
            this.dataGridViewAddresses.TabIndex = 9;
            this.dataGridViewAddresses.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAddresses_CellFormatting);
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelProgress);
            this.panelMain.Controls.Add(this.panelResults);
            this.panelMain.Controls.Add(this.dataGridViewAddresses);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Location = new System.Drawing.Point(12, 38);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(937, 513);
            this.panelMain.TabIndex = 10;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(98, 19);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(111, 24);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Progress...";
            // 
            // panelResults
            // 
            this.panelResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelResults.Controls.Add(this.lblUngeoCount);
            this.panelResults.Controls.Add(this.lblGeocdedCount);
            this.panelResults.Controls.Add(this.lblRecordCount);
            this.panelResults.Controls.Add(this.lblRecords);
            this.panelResults.Controls.Add(this.lblUngeo);
            this.panelResults.Controls.Add(this.lblGeocoded);
            this.panelResults.Controls.Add(this.lblResults);
            this.panelResults.Location = new System.Drawing.Point(14, 255);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(316, 128);
            this.panelResults.TabIndex = 11;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(116, 13);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(70, 20);
            this.lblResults.TabIndex = 0;
            this.lblResults.Text = "Results";
            // 
            // lblGeocoded
            // 
            this.lblGeocoded.AutoSize = true;
            this.lblGeocoded.Location = new System.Drawing.Point(82, 69);
            this.lblGeocoded.Name = "lblGeocoded";
            this.lblGeocoded.Size = new System.Drawing.Size(63, 13);
            this.lblGeocoded.TabIndex = 1;
            this.lblGeocoded.Text = "Geocoded: ";
            // 
            // lblUngeo
            // 
            this.lblUngeo.AutoSize = true;
            this.lblUngeo.Location = new System.Drawing.Point(70, 93);
            this.lblUngeo.Name = "lblUngeo";
            this.lblUngeo.Size = new System.Drawing.Size(75, 13);
            this.lblUngeo.TabIndex = 2;
            this.lblUngeo.Text = "Ungeocoded: ";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(66, 47);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(77, 13);
            this.lblRecords.TabIndex = 3;
            this.lblRecords.Text = "Total Records:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(151, 47);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(0, 13);
            this.lblRecordCount.TabIndex = 4;
            // 
            // lblGeocdedCount
            // 
            this.lblGeocdedCount.AutoSize = true;
            this.lblGeocdedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeocdedCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblGeocdedCount.Location = new System.Drawing.Point(151, 69);
            this.lblGeocdedCount.Name = "lblGeocdedCount";
            this.lblGeocdedCount.Size = new System.Drawing.Size(0, 13);
            this.lblGeocdedCount.TabIndex = 5;
            // 
            // lblUngeoCount
            // 
            this.lblUngeoCount.AutoSize = true;
            this.lblUngeoCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUngeoCount.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUngeoCount.Location = new System.Drawing.Point(151, 93);
            this.lblUngeoCount.Name = "lblUngeoCount";
            this.lblUngeoCount.Size = new System.Drawing.Size(0, 13);
            this.lblUngeoCount.TabIndex = 6;
            // 
            // panelProgress
            // 
            this.panelProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProgress.Controls.Add(this.progressExport);
            this.panelProgress.Controls.Add(this.lblProgress);
            this.panelProgress.Location = new System.Drawing.Point(14, 401);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(316, 95);
            this.panelProgress.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 563);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "BBPO Geocoder v1.0.0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddresses)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCsv;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDefaultOpen;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDefaultSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDefaultSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDefaultOpen;
        private System.Windows.Forms.ProgressBar progressExport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.DataGridView dataGridViewAddresses;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.Label lblUngeoCount;
        private System.Windows.Forms.Label lblGeocdedCount;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblUngeo;
        private System.Windows.Forms.Label lblGeocoded;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Panel panelProgress;
    }
}

