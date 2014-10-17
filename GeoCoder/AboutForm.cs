using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoCoder
{
    /// <summary>
    /// the about form
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// default constructor for the about form.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// the close button click event for the about form, closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
