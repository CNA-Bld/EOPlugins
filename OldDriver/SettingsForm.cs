﻿using System;
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
            foreach (string mapPoint in plugin.settings.MapPoints)
            {
                mapPoints.Add(mapPoint);
            }
            listBox.DataSource = mapPoints;

            mapPointSwitch.Checked = plugin.settings.MapPointEnabled;
            taihaSwitch.Checked = plugin.settings.TaihaEnabled;
            mainSwitch.Checked = plugin.settings.Enabled;
        }

        public override bool Save()
        {
            plugin.settings.MapPoints = mapPoints.OrderBy(i => i).ToList();
            plugin.settings.MapPointEnabled = mapPointSwitch.Checked;
            plugin.settings.TaihaEnabled = taihaSwitch.Checked;
            plugin.settings.Enabled = mainSwitch.Checked;
            plugin.SaveSettings();
            return true;
        }
    }
}
