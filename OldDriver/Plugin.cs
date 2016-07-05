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
        public Settings settings;
        
        public void SaveSettings()
        {
            if (settings == null)
            {
                settings = new Settings();
            }
            if (!Directory.Exists("Settings"))
            {
                Directory.CreateDirectory("Settings");
            }
            File.WriteAllText(PLUGIN_SETTINGS, DynamicJson.Serialize(settings));
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
            if (File.Exists(PLUGIN_SETTINGS))
                settings = DynamicJson.Parse(File.ReadAllText(PLUGIN_SETTINGS)).Deserialize<Settings>();
            else
                settings = new Settings();

            Task.Factory.StartNew(() => FatigueObserver.Instance.Initialize(main, this));

            return true;
        }

        public override PluginSettingControl GetSettings()
        {
            return new SettingsForm( this );
        }
    }
}
