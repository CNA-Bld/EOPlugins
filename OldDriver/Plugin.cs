using Codeplex.Data;
using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ElectronicObserver.Window;
using ElectronicObserver.Notifier;

namespace OldDriver
{
    public class Plugin : ServerPlugin
    {
        private const string PLUGIN_SETTINGS = @"Settings\OldDriver.json";
        private const string DEFAULT_SETTINGS = @"{""MapPoints"":[""3-2-B"",""5-1-A"",""5-1-F""], ""Enabled"":true}";
        public dynamic Settings;
        
        public void SaveSettings()
        {
            if (Settings == null)
            {
                Settings = DynamicJson.Parse(DEFAULT_SETTINGS);
            }
            if (!Directory.Exists("Settings"))
            {
                Directory.CreateDirectory("Settings");
            }
            File.WriteAllText(PLUGIN_SETTINGS, Settings.ToString());
        }


        public override string MenuTitle
        {
            get
            {
                return "老司机防疲劳";
            }
        }

        public override bool RunService(FormMain main)
        {
            try
            {
                if (File.Exists(PLUGIN_SETTINGS))
                    Settings = DynamicJson.Parse(File.ReadAllText(PLUGIN_SETTINGS));
                else
                    Settings = DynamicJson.Parse(DEFAULT_SETTINGS);
            }
            catch (Exception ex)
            {
                Settings = DynamicJson.Parse(DEFAULT_SETTINGS);
            }

            Task.Factory.StartNew(() => FatigueObserver.Instance.Initialize(main, this));

            return true;
        }

        public override PluginSettingControl GetSettings()
        {
            return new Settings( this );
        }
    }
}
