using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicObserver.Window;
using ElectronicObserver.Notifier;

namespace WhiteFleet
{
    public class Plugin : ServerPlugin
    {
        public override string MenuTitle
        {
            get
            {
                return "ホワイト艦隊";
            }
        }

        public override bool RunService(FormMain main)
        {
            Task.Factory.StartNew(() => WhiteObserver.Instance.Initialize());

            return true;
        }

        public override PluginSettingControl GetSettings()
        {
            return null;
        }
    }
}
