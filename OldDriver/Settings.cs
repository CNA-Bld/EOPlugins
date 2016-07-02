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
    public partial class Settings : PluginSettingControl
    {

        private Plugin plugin;

        public Settings(Plugin plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        private BindingList<string> mapPoints;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!mapPoints.Contains(mapPointInput.Text))
            {
                mapPoints.Add(mapPointInput.Text);
                mapPointInput.Text = string.Empty;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mapPoints.Remove((string)listBox1.SelectedItem);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            mapPoints = new BindingList<string>();
            foreach (string mapPoint in plugin.Settings.MapPoints)
            {
                mapPoints.Add(mapPoint);
            }
            listBox1.DataSource = mapPoints;

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
