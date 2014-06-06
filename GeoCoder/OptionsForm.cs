﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoCoder.Properties;

namespace GeoCoder
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            txtbxResultsEmail.Text = Properties.Settings.Default.EmailAddressResults;
            txtbxUngeoEmail.Text = Properties.Settings.Default.EmailAddressUngeo;
            txtbxInHouseCutoffReference.Text = Properties.Settings.Default.ReferenceCutoff.ToString();
            txtbxSmtpHost.Text = Properties.Settings.Default.EmailHost;
            txtbxSmtpPort.Text = Properties.Settings.Default.EmailPort.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
	        {
                Properties.Settings.Default.EmailAddressResults = txtbxResultsEmail.Text;
                Properties.Settings.Default.EmailAddressUngeo = txtbxUngeoEmail.Text;
                Properties.Settings.Default.ReferenceCutoff = Int32.Parse(txtbxInHouseCutoffReference.Text);

                Properties.Settings.Default.EmailHost = txtbxSmtpHost.Text;
                Properties.Settings.Default.EmailPort = Int32.Parse(txtbxSmtpPort.Text);
                Properties.Settings.Default.Save();

                Close();
	        }
	        catch (Exception ex)
	        {
                int res;

                // not sure if this is the most efficient way to do this, but is working for now...
                if (Int32.TryParse(txtbxInHouseCutoffReference.Text, out res))
                {
                    MessageBox.Show("Please enter a valid SMTP Port");
                }
                else if (Int32.TryParse(txtbxSmtpPort.Text, out res))
                {
                    MessageBox.Show("Please enter a valid reference cutoff");
                }
                else if (!(Int32.TryParse(txtbxInHouseCutoffReference.Text, out res)) && 
                    (Int32.TryParse(txtbxSmtpPort.Text, out res)))
                {
                    MessageBox.Show("System error. Please see your administrator" + ex.Message);
                }
                else
                {
                    MessageBox.Show("Please enter a valid SMTP Port and valid reference cutoff number");
                }
	        }
        }

        private void SetDefaultOpenLocation_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogOpen.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.DefaultOpen = folderBrowserDialogOpen.SelectedPath;
        }

        private void SetDefaultSaveLocation_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSave.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.DefaultSave = folderBrowserDialogSave.SelectedPath;
        }
    }
}