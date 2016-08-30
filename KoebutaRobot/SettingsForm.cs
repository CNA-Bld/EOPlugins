using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicObserver.Window.Plugins;

namespace KoebutaRobot
{
    public partial class SettingsForm : PluginSettingControl
    {
        private Plugin plugin;

        public SettingsForm(Plugin plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBoxEnabled.Checked = plugin.settings.Enabled;
            textBoxServer.Text = plugin.settings.Server;
            textBoxTarget.Text = plugin.settings.Target;
            textBoxTargetID.Text = plugin.settings.Tid;
            checkBoxOnlySelectedPoints.Checked = plugin.settings.ReportOnlyOnSelectedPoints;
            textBoxSelectedPoints.Text = plugin.settings.SelectedPoints;
        }

        public override bool Save()
        {
            plugin.settings.Enabled = checkBoxEnabled.Checked;
            plugin.settings.Server = textBoxServer.Text;
            plugin.settings.Target = textBoxTarget.Text;
            plugin.settings.Tid = textBoxTargetID.Text;
            plugin.settings.ReportOnlyOnSelectedPoints = checkBoxOnlySelectedPoints.Checked;
            plugin.settings.SelectedPoints = textBoxSelectedPoints.Text;
            plugin.SaveSettings();
            return true;
        }

        private void textBoxTarget_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxTarget.Text)) return;
            if (!new string[] { "g", "d", "u" }.Contains(textBoxTarget.Text))
            {
                textBoxTarget.Text = "";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
