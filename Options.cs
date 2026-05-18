using System;
using System.Windows.Forms;

namespace synapsex
{
    public partial class OptionsForm : Form
    {
        private Main mainForm;
        public OptionsForm(Main main)
        {
            InitializeComponent();
            this.mainForm = main;

            // Load saved settings
            checkBox1.Checked = Properties.Settings.Default.TopMost;
            checkBox2.Checked = Properties.Settings.Default.autoinj;

            this.TopMost = Properties.Settings.Default.TopMost;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle TopMost and save setting
            Properties.Settings.Default.TopMost = checkBox1.Checked;
            Properties.Settings.Default.Save();

            if (mainForm != null)
            {
                mainForm.TopMost = checkBox1.Checked;
            }
            this.TopMost = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle Auto Inject and save setting
            Properties.Settings.Default.autoinj = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            // Apply saved settings on form load
            this.TopMost = Properties.Settings.Default.TopMost;
        }
    }
}
