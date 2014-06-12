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
            this.btnExportBailiff = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLoad = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogCsv = new System.Windows.Forms.SaveFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.progressExport = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnEmailUngeo = new System.Windows.Forms.Button();
            this.btnExportInhouse = new System.Windows.Forms.Button();
            this.btnGeocode = new System.Windows.Forms.Button();
            this.dataGridViewAddresses = new System.Windows.Forms.DataGridView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelResults = new System.Windows.Forms.Panel();
            this.lblUngeoCount = new System.Windows.Forms.Label();
            this.lblGeocdedCount = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblUngeo = new System.Windows.Forms.Label();
            this.lblGeocoded = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddresses)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportBailiff
            // 
            this.btnExportBailiff.Location = new System.Drawing.Point(85, 151);
            this.btnExportBailiff.Name = "btnExportBailiff";
            this.btnExportBailiff.Size = new System.Drawing.Size(101, 30);
            this.btnExportBailiff.TabIndex = 2;
            this.btnExportBailiff.Text = "Export Bailiff";
            this.btnExportBailiff.UseVisualStyleBackColor = true;
            this.btnExportBailiff.Click += new System.EventHandler(this.buttonExportBailiff_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(964, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.optionsToolStripMenuItem,
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(85, 78);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(101, 30);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import CSV";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // progressExport
            // 
            this.progressExport.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressExport.Location = new System.Drawing.Point(3, 29);
            this.progressExport.Name = "progressExport";
            this.progressExport.Size = new System.Drawing.Size(262, 23);
            this.progressExport.Step = 4;
            this.progressExport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressExport.TabIndex = 6;
            this.progressExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "CSV Geocoder";
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButtons.Controls.Add(this.btnEmailUngeo);
            this.panelButtons.Controls.Add(this.btnExportInhouse);
            this.panelButtons.Controls.Add(this.btnGeocode);
            this.panelButtons.Controls.Add(this.label2);
            this.panelButtons.Controls.Add(this.btnExportBailiff);
            this.panelButtons.Controls.Add(this.btnImport);
            this.panelButtons.Location = new System.Drawing.Point(14, 14);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(272, 284);
            this.panelButtons.TabIndex = 8;
            // 
            // btnEmailUngeo
            // 
            this.btnEmailUngeo.Location = new System.Drawing.Point(85, 224);
            this.btnEmailUngeo.Name = "btnEmailUngeo";
            this.btnEmailUngeo.Size = new System.Drawing.Size(101, 30);
            this.btnEmailUngeo.TabIndex = 10;
            this.btnEmailUngeo.Text = "Email Ungeo";
            this.btnEmailUngeo.UseVisualStyleBackColor = true;
            this.btnEmailUngeo.Click += new System.EventHandler(this.btnEmailUngeo_Click);
            // 
            // btnExportInhouse
            // 
            this.btnExportInhouse.Location = new System.Drawing.Point(85, 187);
            this.btnExportInhouse.Name = "btnExportInhouse";
            this.btnExportInhouse.Size = new System.Drawing.Size(101, 30);
            this.btnExportInhouse.TabIndex = 9;
            this.btnExportInhouse.Text = "Export In-House";
            this.btnExportInhouse.UseVisualStyleBackColor = true;
            this.btnExportInhouse.Click += new System.EventHandler(this.btnExportInhouse_Click);
            // 
            // btnGeocode
            // 
            this.btnGeocode.Location = new System.Drawing.Point(85, 114);
            this.btnGeocode.Name = "btnGeocode";
            this.btnGeocode.Size = new System.Drawing.Size(101, 30);
            this.btnGeocode.TabIndex = 8;
            this.btnGeocode.Text = "Geocode";
            this.btnGeocode.UseVisualStyleBackColor = true;
            this.btnGeocode.Click += new System.EventHandler(this.btnGeocode_Click);
            // 
            // dataGridViewAddresses
            // 
            this.dataGridViewAddresses.AllowUserToAddRows = false;
            this.dataGridViewAddresses.AllowUserToDeleteRows = false;
            this.dataGridViewAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAddresses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddresses.Location = new System.Drawing.Point(292, 14);
            this.dataGridViewAddresses.Name = "dataGridViewAddresses";
            this.dataGridViewAddresses.Size = new System.Drawing.Size(631, 482);
            this.dataGridViewAddresses.TabIndex = 9;
            this.dataGridViewAddresses.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAddresses_CellFormatting);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelProgress);
            this.panelMain.Controls.Add(this.panelResults);
            this.panelMain.Controls.Add(this.dataGridViewAddresses);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Location = new System.Drawing.Point(12, 38);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(940, 513);
            this.panelMain.TabIndex = 10;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panelProgress
            // 
            this.panelProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProgress.Controls.Add(this.progressExport);
            this.panelProgress.Controls.Add(this.lblProgress);
            this.panelProgress.Location = new System.Drawing.Point(14, 438);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(272, 58);
            this.panelProgress.TabIndex = 12;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(81, 0);
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
            this.panelResults.Location = new System.Drawing.Point(14, 304);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(272, 128);
            this.panelResults.TabIndex = 11;
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
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(151, 47);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(0, 13);
            this.lblRecordCount.TabIndex = 4;
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
            // lblUngeo
            // 
            this.lblUngeo.AutoSize = true;
            this.lblUngeo.Location = new System.Drawing.Point(70, 93);
            this.lblUngeo.Name = "lblUngeo";
            this.lblUngeo.Size = new System.Drawing.Size(75, 13);
            this.lblUngeo.TabIndex = 2;
            this.lblUngeo.Text = "Ungeocoded: ";
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
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(90, 10);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(70, 20);
            this.lblResults.TabIndex = 0;
            this.lblResults.Text = "Results";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 563);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStripMain);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "CSV Geocoder v1.0.0.8";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddresses)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportBailiff;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCsv;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar progressExport;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Button btnExportInhouse;
        private System.Windows.Forms.Button btnGeocode;
        private System.Windows.Forms.Button btnEmailUngeo;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

