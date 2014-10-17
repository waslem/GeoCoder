using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoCoder.Properties;
using GeoCoder.Encrypt;

namespace GeoCoder
{
    /// <summary>
    /// The options form, displays the configurable options of the geocoder application
    /// </summary>
    public partial class OptionsForm : Form
    {
        /// <summary>
        /// the default constructor for the options form, initialises the settings from the
        /// programs settings resources.
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();

            // set the GUI text fields to the value in the software settings
            txtbxResultsEmail.Text = Properties.Settings.Default.EmailAddressResults;
            txtbxUngeoEmail.Text = Properties.Settings.Default.EmailAddressUngeo;
            txtbxInHouseCutoffReference.Text = Properties.Settings.Default.ReferenceCutoff.ToString();
            txtbxSmtpHost.Text = Properties.Settings.Default.SmtpHost;
            txtbxSmtpPort.Text = Properties.Settings.Default.SmtpPort.ToString();

            txtBoxSmtpUser.Text = Properties.Settings.Default.EmailUsername;
            txtBoxSmtpPass.Text = Properties.Settings.Default.EmailPassword;

            txtBoxProxyAddress.Text = Properties.Settings.Default.ProxyAddress;
            txtBoxProxyUsername.Text = Properties.Settings.Default.proxyUsername;
            txtBoxProxyPassword.Text = Properties.Settings.Default.proxyPassword;

          
            dropDownListGeo.SelectedIndex = 1;
        }

        /// <summary>
        /// This method handles the cancel button click event
        /// This method closes the OptionsForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// This method handles the save button click event
        /// The method attempts to save all settings that were changed in the options form by the user
        /// Some validation is performed on integer values to ensure data types are correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
	        {
                Properties.Settings.Default.EmailAddressResults = txtbxResultsEmail.Text;
                Properties.Settings.Default.EmailAddressUngeo = txtbxUngeoEmail.Text;
                Properties.Settings.Default.ReferenceCutoff = Int32.Parse(txtbxInHouseCutoffReference.Text);

                Properties.Settings.Default.SmtpHost = txtbxSmtpHost.Text;
                Properties.Settings.Default.SmtpPort = Int32.Parse(txtbxSmtpPort.Text);

                Crypto crypt = new Crypto(CryptoType: Crypto.CryptoTypes.encTypeTripleDES);
                string emailPass = crypt.Encrypt(txtBoxSmtpPass.Text);
                string proxyPass = crypt.Encrypt(txtBoxProxyPassword.Text);

                Properties.Settings.Default.EmailUsername = txtBoxSmtpUser.Text;
                Properties.Settings.Default.EmailPassword = emailPass;

                Properties.Settings.Default.ProxyAddress = txtBoxProxyAddress.Text;
                Properties.Settings.Default.proxyUsername = txtBoxProxyUsername.Text;
                Properties.Settings.Default.proxyPassword = proxyPass;

                Properties.Settings.Default.Save();

                Close();
	        }
            // error checking for fields which are integers
	        catch (Exception ex)
	        {
                int res;

                // not sure if this is the most efficient way to do this
                // TODO: review and revise this in the future
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

        /// <summary>
        /// This method handles the set default open location click event
        /// The folderBrowserDialogopen dialog box is shown and if the DialogResult is OK we save the
        /// selected path as the default open path for the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDefaultOpenLocation_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogOpen.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.DefaultOpen = folderBrowserDialogOpen.SelectedPath;
        }

        /// <summary>
        /// This method handles the set default save location click event
        /// The folderBrowserDialogSave dialog box is shown and if the DialogResult is OK we save the
        /// selected path as the default save path for the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDefaultSaveLocation_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSave.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.DefaultSave = folderBrowserDialogSave.SelectedPath;
        }
    }
}
