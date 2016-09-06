using Codeplex.Data;
using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ElectronicObserver.Data;
using ElectronicObserver.Window;
using ElectronicObserver.Notifier;
using Fiddler;
using Logger = ElectronicObserver.Utility.Logger;

namespace Everstone
{
    public class Plugin : ServerPlugin
    {
        private const string PLUGIN_SETTINGS = @"Settings\Everstone.json";
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
                return "変わらずの石";
            }
        }

        public override bool RunService(FormMain main)
        {
            if (File.Exists(PLUGIN_SETTINGS))
                settings = DynamicJson.Parse(File.ReadAllText(PLUGIN_SETTINGS)).Deserialize<Settings>();
            else
                settings = new Settings();

            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            return true;
        }

        public override PluginSettingControl GetSettings()
        {
            return new SettingsForm(this);
        }

        private void FiddlerApplication_BeforeRequest(Session oSession)
        {
            if (!settings.Enabled) return;
            if (oSession.fullUrl.Substring(oSession.fullUrl.IndexOf("/kcsapi/") + 8) == "api_req_kaisou/remodeling")
            {
                string result = onRemodeling(oSession.GetRequestBodyAsString());
                if (result != null)
                {
                    Logger.Add(2, result);
                    oSession.oResponse.headers.HTTPResponseCode = 502;
                    oSession.utilCreateResponseAndBypassServer();
                    oSession.oResponse.headers.HTTPResponseCode = 502;
                }
            }
        }

        private string onRemodeling(string body)
        {
            var api = GetAPI(body);
            if (api.ContainsKey("api.id"))
            {
                string shipId = api["api.id"];
                if (settings.ProtectedShips.Contains(shipId))
                {
                    ShipData shipData = KCDatabase.Instance.Ships[int.Parse(shipId)];
                    return $"试图改造携带不变之石的舰娘 [{shipId}] {shipData.NameWithLevel}";
                }
            }
            return null;
        }

        private static Dictionary<string, string> GetAPI(string body)
        {
            string[] strArray = body.Replace("%5F", ".").Replace("%2C", ",").Split('&');
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string s in strArray)
            {
                int length = s.IndexOf("=");
                if (length > 3)
                {
                    string index = s.Substring(0, length);
                    string str2 = s.Substring(Math.Min(length + 1, s.Length));
                    dictionary[index] = str2;
                }
            }
            return dictionary;
        }
    }
}
