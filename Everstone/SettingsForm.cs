using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicObserver.Data;
using ElectronicObserver.Window.Plugins;

namespace Everstone
{
    public partial class SettingsForm : PluginSettingControl
    {
        private Plugin plugin;
        private BindingList<ProtectedShip> protectedShips;

        public SettingsForm(Plugin plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBoxEnabled.Checked = plugin.settings.Enabled;
            try
            {
                protectedShips =
                    new BindingList<ProtectedShip>(
                        plugin.settings.ProtectedShips.FindAll(s => KCDatabase.Instance.Ships.ContainsKey(int.Parse(s)))
                            .Select(s => new ProtectedShip(s))
                            .ToList());
                listBoxProtectedShips.DataSource = protectedShips;
            }
            catch (NullReferenceException)
            {
                
            }
            listBoxProtectedShips.DisplayMember = "DisplayName";
            listBoxProtectedShips.ValueMember = "Id";
        }

        public override bool Save()
        {
            plugin.settings.Enabled = checkBoxEnabled.Checked;
            plugin.settings.ProtectedShips = protectedShips.Select(s => s.Id).ToList();
            plugin.SaveSettings();
            return true;
        }

        private class ProtectedShip
        {
            private int shipId;

            public ProtectedShip(string shipId)
            {
                this.shipId = int.Parse(shipId);
            }

            public string DisplayName
            {
                get { return $"[{shipId}] {KCDatabase.Instance.Ships[shipId].NameWithLevel}"; }
            }

            public string Id
            {
                get { return shipId.ToString(); }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var member in KCDatabase.Instance.Fleet[1].Members)
                {
                    if (member != -1 && !protectedShips.Select(s => s.Id).Contains(member.ToString()))
                    {
                        protectedShips.Add(new ProtectedShip(member.ToString()));
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            protectedShips.Remove((ProtectedShip) listBoxProtectedShips.SelectedItem);
        }
    }
}