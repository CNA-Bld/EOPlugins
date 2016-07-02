using ElectronicObserver.Window.Dialog;
using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserLocator
{
    public class Plugin : DialogPlugin
    {
        public override string MenuTitle
        {
            get
            {
                return "Get Browser Handle";
            }
        }

        public override PluginSettingControl GetSettings()
        {
            return null;
        }

        public override Form GetToolWindow()
        {
            return new BrowserLocatorWindow();
        }
    }
}
