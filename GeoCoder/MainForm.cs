using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ComLib.CsvParse;
using GeoCoder.logic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;

namespace GeoCoder
{
    public partial class MainForm : Form
    {
        private List<Address> _ungeoList = null;
        private ResultStats _resultStats;

        private string _defaultSave = "K:\\";
        private string _defaultOpen = "C:\\X-Y Files\\";

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
            {
                _defaultSave = folderBrowserDefaultSave.SelectedPath;
            }
        }

        // default close
        private void toolStripMenuDefaultSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDefaultOpen.ShowDialog() == DialogResult.OK)
            {
                _defaultOpen = folderBrowserDefaultOpen.SelectedPath;
            }
        }

        // exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // open csv from open in menu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCsv();
        }

        // open csv from button
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

            // set cursor to wait cursor.
            Cursor.Current = Cursors.WaitCursor;

            // set the label and progress bar to visible
            DisplayProgress();

            // use this to force the application to repaint the form directly after the
            // label and progress bar are set to visible
            // see http://msdn.microsoft.com/en-us/library/system.windows.forms.application.doevents%28v=vs.110%29.aspx
            //      "if you remove DoEvents from your code, your form will not repaint until 
            //      the click event handler of the button is finished executing."
            Application.DoEvents();

            // geocode/sort and export all addresses in ungeoList
            Geocode();
            SortResults();
            ExportResults();

            dataGridViewAddresses.DataSource = _ungeoList;

            // set progress bar invisible again and cursor back to default
            Cursor.Current = Cursors.Default;

            HideProgress();
            CalculateResults();
            UpdateResultsPanel();
        }

        private void UpdateResultsPanel()
        {
            this.lblRecordCount.Text = this._resultStats.RecordCount.ToString();
            this.lblGeocdedCount.Text = this._resultStats.GeocodedCount.ToString();
            this.lblUngeoCount.Text = this._resultStats.UngeocodedCount.ToString();
        }

        private void CalculateResults()
        {
            this._resultStats.RecordCount = _ungeoList.Count;

            int i = 0;

            foreach (var address in _ungeoList)
            {
                if (address.X > 0)
                {
                    i++;
                }
            }

            this._resultStats.GeocodedCount = i;
            this._resultStats.UngeocodedCount = this._resultStats.RecordCount - i;
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
            
            foreach (var a in _ungeoList)
            {
                a.Geocode();
                
                // progress bar steps
                progressExport.PerformStep();
            }
        }

        private void LoadCsv(string fileName)
        {
            try
            {
                CsvDoc csv = Csv.Load(fileName, true);

                // hack way to do this now, will think of better way later.
                // TODO: fix the loading the csv to be more robust
                foreach (OrderedDictionary t in csv.Data)
                {
                    // assumes input from csv is in correct format
                    _ungeoList.Add(new Address(t[0] as string, t[1] as string));
                }
            }
            catch (IOException)
            {
                MessageBox.Show(@"The file you are trying to access is currently open by another process, please close it and try again.");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataGridViewAddresses.Show();
                dataGridViewAddresses.DataSource = _ungeoList;
            }
        }

        private void OpenCsv()
        {
            openFileLoad.InitialDirectory = _defaultOpen;
            openFileLoad.Filter = @"csv files (*.csv)| *.csv";

            DialogResult result = openFileLoad.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadCsv(openFileLoad.FileName);
            }
        }

        private void ExportResults()
        {
            saveFileDialogCsv.InitialDirectory = _defaultSave;
            saveFileDialogCsv.Filter = @"csv files (*.csv)| *.csv";

            DialogResult result = saveFileDialogCsv.ShowDialog();

            if (result == DialogResult.OK)
            {
                //CsvExported generic class, exports a group of any type of objects to csv, in this case we export our list of address objects
                var export = new CsvExport<Address>(_ungeoList);
                export.ExportToFile(saveFileDialogCsv.FileName);
            }
        }

        public void SortResults()
        {
            //sort list by y then x then ordernumber
            _ungeoList = _ungeoList.OrderBy(address => address.Y)
                                .ThenBy(address => address.X)
                                .ThenBy(address => address.OrderNum)
                                .ToList();
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
               {
                   e.CellStyle.BackColor = Color.LightGreen; 
               }
               else
               {
                   e.CellStyle.BackColor = Color.LightPink;
               }
           }
        }
    }
}
