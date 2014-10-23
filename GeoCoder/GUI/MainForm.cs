using System;
using System.Windows.Forms;
using ComLib.CsvParse;
using GeoCoder.logic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using ComLib.Logging;

namespace GeoCoder
{
    /// <summary>
    /// This class is the main form used for the Geocoder GUI
    /// </summary>
    public partial class MainForm : Form
    {
        private List<Address> _ungeoList = null;
        private ResultStats _resultStats;

        /// <summary>
        /// The default contstructor for the main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method handles the event for loading the main form.
        /// The main form used to display the GUI for the geocoder application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // create a new ungeo list and result statistics object
            _ungeoList = new List<Address>();
            _resultStats = new ResultStats();
            
            // set the initial button and datagrid configuration
            dataGridViewAddresses.Visible = false;
            btnGeocode.Enabled = false;
            btnExportBailiff.Enabled = false;
            btnExportInhouse.Enabled = false;
            btnEmailUngeo.Enabled = false;

            // hide the progress bar
            HideProgress();

            // create the simple logger to log events for the administrator to diagnose.
            GeoCoderHelpers.CreateLogger();
            
            // log the launched event, whenever the program is loaded.
            GeoCoderHelpers.LogEvent(LogLevel.Info, "Geocoder Launched");
        }

        /// <summary>
        /// This method handles the exit tool strip menu item click event.
        /// This causes the application to close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// This method handles the open csv menu item click event
        /// this causes the application to open the csv file selected by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCsv();
        }

        /// <summary>
        /// This method handles the Import button click event
        /// This causes the application to open the csv file selected by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            ResetAddressAndResults();

            if (OpenCsv() == true)
            {
                btnImport.BackColor = Color.Green;
                btnGeocode.Enabled = true;
            }
        }

        /// <summary>
        /// This method resets the ungeo list and the results statistics
        /// </summary>
        private void ResetAddressAndResults()
        {
            this._ungeoList.Clear();
            this._resultStats.Reset();
        }

        /// <summary>
        /// This method handles the export button click event
        /// This causes the application to attempt to export the results for bailiff data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            ExportResultsBailiff();
            btnExportBailiff.BackColor = Color.Green;
        }

        /// <summary>
        /// Update the results panel with the statistics from the resultStats collection
        /// </summary>
        private void UpdateResultsPanel()
        {
            this.lblRecordCount.Text = this._resultStats.RecordCount.ToString();
            this.lblGeocdedCount.Text = this._resultStats.GeocodedCount.ToString();
            this.lblUngeoCount.Text = this._resultStats.UngeocodedCount.ToString();
        }

        /// <summary>
        /// Set the progress bar and label to display
        /// </summary>
        private void DisplayProgress()
        {
            progressExport.Visible = true;
            lblProgress.Visible = true;
        }

        /// <summary>
        /// Set the progress and label to not display
        /// </summary>
        private void HideProgress()
        {
            progressExport.Visible = false;
            lblProgress.Visible = false;
        }

        /// <summary>
        /// This method handles attempting to geocode each order that is in the _ungeoList collection
        /// </summary>
        private void Geocode()
        {
            // set the step to 1 and the maximum steps to the # of records to geocode
            progressExport.Step = 1;
            progressExport.Maximum = _ungeoList.Count;

            for (int i = 0; i < _ungeoList.Count; i++)
            {
                _ungeoList[i] = GeoCoderHelpers.GeoCode(_ungeoList[i]);
                progressExport.PerformStep();
            }
        }

        /// <summary>
        ///  This method attempts to load a csv file from the filename specified
        /// </summary>
        /// <param name="fileName">the file name of the file to open</param>
        private void LoadCsv(string fileName)
        {
            bool success = false;

            try
            {
                GeoCoderHelpers.LoadCsv(fileName, _ungeoList);
                success = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(Properties.Settings.Default.FileInUseMessage);
                _ungeoList = new List<Address>();
                GeoCoderHelpers.LogEvent(LogLevel.Error, "the file is in use, error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);
                _ungeoList = new List<Address>();
                GeoCoderHelpers.LogEvent(LogLevel.Error, "an unexpected exception occured, error: " + ex.Message);
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

        /// <summary>
        /// This method is used to open a csv file from the user's machine.
        /// This method can only successfully open csv files with data in the following example format:
        /// "OrderNum","Address"
        /// "12345","65 harris road Gingin WA 6503"
        /// </summary>
        /// <returns>true if the file was successfully opened.</returns>
        private bool OpenCsv()
        {
            bool status = false;
            ResetAddressAndResults();

            openFileLoad.InitialDirectory = Properties.Settings.Default.DefaultOpen;
            openFileLoad.Filter = Properties.Settings.Default.CsvFilter;
            DialogResult result = openFileLoad.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadCsv(openFileLoad.FileName);
                status = true;
            }

            return status;
        }

        /// <summary>
        /// This method is used to export the Bailiff results to the configured default export location
        /// </summary>
        private void ExportResultsBailiff()
        {
            saveFileDialogCsv.InitialDirectory = Properties.Settings.Default.DefaultSave;
            saveFileDialogCsv.Filter = Properties.Settings.Default.CsvFilter;
            saveFileDialogCsv.FileName = GeoCoderHelpers.SetUngeoFileNameWithTodaysDate("bailiff");

            DialogResult result = saveFileDialogCsv.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    // convertlist extra variable, have this as an option to allow cut off limit for reference numbers
                    // this will allow you to dynamically assign the cut off limit for inhouse / bailiff in the options
                    // will fix potential future issues

                   // geocoderhelpers.convertlist(ungeolist, startreference, finishreference)
                    List<AddressExport> exportList = GeoCoderHelpers
                        .ConvertList(_ungeoList, Properties.Settings.Default.ReferenceCutoff, 200000);

                    //CsvExported generic class, exports a group of any type of objects to csv, in this case we export our list of address objects
                    // var export = new CsvExport<Address>(_ungeolist);
                    var export = new CsvExport<AddressExport>(exportList);
                    export.ExportToFile(saveFileDialogCsv.FileName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(Properties.Settings.Default.FileInUseMessage);
                    GeoCoderHelpers.LogEvent(LogLevel.Error, "the file is in use during export bailiff method, error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);
                    GeoCoderHelpers.LogEvent(LogLevel.Error, "unexpected error during export bailiff method , error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// This method handles the about tool strip menu click event
        /// This method simply launches the about form and shows the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        /// <summary>
        /// This method formats the datagrid view when the dataGrid cell formatting event is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// paint event on the panel, set the color of the panel border to light gray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.LightGray,1))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(1, 1, panelMain.ClientSize.Width - 2,
                                                                panelMain.ClientSize.Height - 2));
            }
        }

        /// <summary>
        ///  This method handles the btnGeocode click event
        ///  This method then calls the Geocode method to handle the actual geocoding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeocode_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DisplayProgress();

            // use this to force the application to repaint the form directly after the
            // label and progress bar are set to visible
            Application.DoEvents();
            Geocode();
            _ungeoList = GeoCoderHelpers.SortResults(_ungeoList);

            Cursor.Current = Cursors.Default;
            HideProgress();

            dataGridViewAddresses.DataSource = _ungeoList;
            _resultStats = GeoCoderHelpers.CalculateResults(_ungeoList);

            UpdateResultsPanel();

            btnGeocode.BackColor = Color.Green;
            btnExportBailiff.Enabled = true;
            btnExportInhouse.Enabled = true;
            btnEmailUngeo.Enabled = true;

        }

        /// <summary>
        /// This method handles the email ungeo button click event
        /// This method creatse the email and sends the email to the required recipients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmailUngeo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Email email = new Email();

            // try send the ungeo and results emails
            if (email.SendRemainingUngeocoded(Properties.Settings.Default.EmailAddressUngeo, _ungeoList) &&
                email.SendResultStatistics(Properties.Settings.Default.EmailAddressResults, _resultStats))
            {
                Cursor.Current = Cursors.Default;
                btnEmailUngeo.BackColor = Color.Green;
                MessageBox.Show("Email with ungeocoded records sent!");
                GeoCoderHelpers.LogEvent(LogLevel.Info, "email sent to server");
            }
            else
            {
                Cursor.Current = Cursors.Default;
                btnEmailUngeo.BackColor = Color.Red;
                MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);
                GeoCoderHelpers.LogEvent(LogLevel.Error, "error during sending the email");
            }
        }

        /// <summary>
        /// This method handles the export in-house button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportInhouse_Click(object sender, EventArgs e)
        {
            ExportResultsInhouse();
            btnExportInhouse.BackColor = Color.Green;
        }

        /// <summary>
        /// This method handles the exporting of in-house orders
        /// This method is triggered by the btnExportInHouse_Click event
        /// </summary>
        private void ExportResultsInhouse()
        {
            saveFileDialogCsv.InitialDirectory = Properties.Settings.Default.DefaultSave;
            saveFileDialogCsv.FileName = "";
            saveFileDialogCsv.Filter = Properties.Settings.Default.CsvFilter;
            saveFileDialogCsv.FileName = GeoCoderHelpers.SetUngeoFileNameWithTodaysDate("inhouse");

            DialogResult result = saveFileDialogCsv.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    // convertlist extra variable, have this as an option to allow cut off limit for reference numbers
                    // this will allow you to dynamically assign the cut off limit for inhouse / bailiff in the options
                    // will fix potential future issues

                    // geocoderhelpers.convertlist(ungeolist, startreference, finishreference)
                    List<AddressExport> exportList = GeoCoderHelpers
                        .ConvertList(_ungeoList, 0, Properties.Settings.Default.ReferenceCutoff);

                    //CsvExported generic class, exports a group of any type of objects to csv, in this case we export our list of address objects
                    // var export = new CsvExport<Address>(_ungeolist);
                    var export = new CsvExport<AddressExport>(exportList);

                    // export to 
                    export.ExportToFile(saveFileDialogCsv.FileName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(Properties.Settings.Default.FileInUseMessage);
                    GeoCoderHelpers.LogEvent(LogLevel.Error, "the file is in use during export bailiff , error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.Settings.Default.UnexpectedErrorMessage);
                    GeoCoderHelpers.LogEvent(LogLevel.Error, "an unexpected error occured, error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// This method handles the export bailiff button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExportBailiff_Click(object sender, EventArgs e)
        {
            ExportResultsBailiff();
            btnExportBailiff.BackColor = Color.Green;
        }

        /// <summary>
        ///  This method handles the options form click event, this launches the options form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }
    }
}
