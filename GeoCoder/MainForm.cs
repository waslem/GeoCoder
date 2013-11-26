using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ComLib.CsvParse;
using GeoCoder.logic;

namespace GeoCoder
{
    public partial class MainForm : Form
    {
        private List<Address> _ungeoList = null;

        private string _defaultSave = "c:\\";
        private string _defaultOpen = "c:\\";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ungeoList = new List<Address>();
            
            progressExport.Visible = false;
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
            OpenCsv();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            // set cursor to wait cursor.
            Cursor.Current = Cursors.WaitCursor;

            // geocode/sort and export all addresses in ungeoList
            Geocode();
            SortResults();
            ExportResults();

            // set progress bar invisible again and cursor back to default
            Cursor.Current = Cursors.Default;
            progressExport.Visible = false;
        }

        private void Geocode()
        {
            progressExport.Visible = true;

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
    }
}
