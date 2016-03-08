using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace srtclean
{

    public partial class FormSRTClean : Form
    {
        private SRTCleaner cleaner = new SRTCleaner();
    
        public FormSRTClean()
        {
            InitializeComponent();
        }

        private void buttonOpenSRT_Click(object sender, EventArgs e)
        {
            openFileDialogSRT.ShowDialog();
        }

        private void buttonEDL_Click(object sender, EventArgs e)
        {
            openFileDialogEDL.ShowDialog();
        }

        private void openFileDialogSRT_FileOk(object sender, CancelEventArgs e)
        {
            textBoxSRT.Text = openFileDialogSRT.FileName;
            cleaner.SRTFileName = openFileDialogSRT.FileName;
            textBoxOutput.Text = cleaner.cleanSRT();
        }

        private void openFileDialogEDL_FileOk(object sender, CancelEventArgs e)
        {
            textBoxEDL.Text = openFileDialogEDL.FileName;
            cleaner.EDLFileName = openFileDialogEDL.FileName;
            textBoxOutput.Text = cleaner.cleanSRT();
        }

    }
}