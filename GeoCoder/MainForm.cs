using System;
using System.Windows.Forms;
using ComLib.CsvParse;
using GeoCoder.logic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace GeoCoder
{
    public partial class MainForm : Form
    {
        private List<Address> _ungeoList = null;
        private ResultStats _resultStats;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ungeoList = new List<Address>();
            _resultStats = new ResultStats();
            dataGridViewAddresses.Visible = false;

            HideProgress();
        }

        // default open
        private void toolStripMenuDefaultOpen_Click(object sender, EventArgs e)
        {
            if (folderBrowserDefaultSave.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.DefaultSave = folderBrowserDefaultSave.SelectedPath;
        }

        // default close
        private void toolStripMenuDefaultSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDefaultOpen.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.DefaultOpen = folderBrowserDefaultOpen.SelectedPath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCsv();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            ResetAddressAndResults();
            OpenCsv();
        }

        private void ResetAddressAndResults()
        {
            this._ungeoList.Clear();
            this._resultStats.Reset();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DisplayProgress();

            // use this to force the application to repaint the form directly after the
            // label and progress bar are set to visible
            Application.DoEvents();
            Geocode();
            _ungeoList = GeoCoderHelpers.SortResults(_ungeoList);

            ExportResults();
            dataGridViewAddresses.DataSource = _ungeoList;
            _resultStats = GeoCoderHelpers.CalculateResults(_ungeoList);
            UpdateResultsPanel();

            Email email = new Email();

            if (email.Send("info@backofficebpo.com.au", _ungeoList) && email.Send("scheduler@backofficebpo.com.au", _resultStats))
            {
                MessageBox.Show("Email with ungeocoded records sent!");
            }
            else
                MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);

            //if (GeoCoderHelpers.EmailUngeo(_ungeoList))
            //    MessageBox.Show("Email with ungeocoded records sent!");
            //else
            //    MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);

            Cursor.Current = Cursors.Default;
            HideProgress();
        }

        private void UpdateResultsPanel()
        {
            this.lblRecordCount.Text = this._resultStats.RecordCount.ToString();
            this.lblGeocdedCount.Text = this._resultStats.GeocodedCount.ToString();
            this.lblUngeoCount.Text = this._resultStats.UngeocodedCount.ToString();
        }

        private void DisplayProgress()
        {
            progressExport.Visible = true;
            lblProgress.Visible = true;
        }

        private void HideProgress()
        {
            progressExport.Visible = false;
            lblProgress.Visible = false;
        }

        private void Geocode()
        {
            for (int i = 0; i < _ungeoList.Count; i++)
            {
                _ungeoList[i] = GeoCoderHelpers.GeoCode(_ungeoList[i]);
                progressExport.PerformStep();
            }
        }

        private void LoadCsv(string fileName)
        {
            bool success = false;

            try
            {
                GeoCoderHelpers.LoadCsv(fileName, _ungeoList);
                success = true;
            }
            catch (IOException)
            {
                MessageBox.Show(Properties.Settings.Default.FileInUseMessage);
                _ungeoList = new List<Address>();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);
                _ungeoList = new List<Address>();
            }
            finally
            {
                // only if successful do we bind the datasource and show addresses
                if (success)
                {
                    dataGridViewAddresses.Show();
                    dataGridViewAddresses.DataSource = _ungeoList;
                }
            }
        }

        private void OpenCsv()
        {
            ResetAddressAndResults();

            openFileLoad.InitialDirectory = Properties.Settings.Default.DefaultOpen;
            openFileLoad.Filter = Properties.Settings.Default.CsvFilter;

            DialogResult result = openFileLoad.ShowDialog();

            if (result == DialogResult.OK)
                LoadCsv(openFileLoad.FileName);
        }

        private void ExportResults()
        {
            saveFileDialogCsv.InitialDirectory = Properties.Settings.Default.DefaultSave;
            saveFileDialogCsv.Filter = Properties.Settings.Default.CsvFilter;

            DialogResult result = saveFileDialogCsv.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    List<AddressExport> exportList = GeoCoderHelpers.ConvertList(_ungeoList);
                    //CsvExported generic class, exports a group of any type of objects to csv, in this case we export our list of address objects
                    // var export = new CsvExport<Address>(_ungeolist);
                    var export = new CsvExport<AddressExport>(exportList);
                    export.ExportToFile(saveFileDialogCsv.FileName);
                }
                catch (IOException)
                {
                    MessageBox.Show(Properties.Settings.Default.FileInUseMessage);
                }
                catch (Exception)
                {
                    MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        private void dataGridViewAddresses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // column 2 = "X" column, column 3 = "Y" column
           if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
           {  
               if (e.Value.ToString() != "0")
                   e.CellStyle.BackColor = Color.LightGreen; 
               else
                   e.CellStyle.BackColor = Color.LightPink;
           }
        }

        // paint event on the panel, set the color of the panel border to light gray.
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.LightGray,1))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(1, 1, panelMain.ClientSize.Width - 2,
                                                                panelMain.ClientSize.Height - 2));
            }
        }
    }
}
