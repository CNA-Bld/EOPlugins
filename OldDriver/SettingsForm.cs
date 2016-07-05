using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicObserver.Window.Plugins;

namespace OldDriver
{
    public partial class SettingsForm : PluginSettingControl
    {

        private Plugin plugin;

        public SettingsForm(Plugin plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        private BindingList<string> mapPoints;

        private void add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mapPointInput.Text) && !mapPoints.Contains(mapPointInput.Text))
            {
                mapPoints.Add(mapPointInput.Text);
                mapPointInput.Text = string.Empty;
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            mapPoints.Remove((string)listBox.SelectedItem);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            mapPoints = new BindingList<string>();
            foreach (string mapPoint in plugin.Settings.MapPoints)
            {
                mapPoints.Add(mapPoint);
            }
            listBox.DataSource = mapPoints;

            mainSwitch.Checked = plugin.Settings.Enabled;
        }

        public override bool Save()
        {
            plugin.Settings.MapPoints = mapPoints.OrderBy(i => i).ToArray();
            plugin.Settings.Enabled = mainSwitch.Checked;
            plugin.SaveSettings();
            return true;
        }
    }
}
