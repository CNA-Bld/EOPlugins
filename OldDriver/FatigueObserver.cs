﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicObserver.Window;
using ElectronicObserver.Observer;
using ElectronicObserver.Data;
using ElectronicObserver.Utility;

namespace OldDriver
{
    class FatigueObserver
    {
        #region Singleton

        private static readonly FatigueObserver instance = new FatigueObserver();

        public static FatigueObserver Instance
        {
            get { return instance; }
        }

        #endregion

        private FormBrowserHost formBrowserHost;
        private Plugin plugin;

        public void Initialize(FormMain main, Plugin plugin)
        {
            this.formBrowserHost = main.fBrowser;
            this.plugin = plugin;

            APIObserver o = APIObserver.Instance;
            o["api_req_map/start"].ResponseReceived += Advanced;
            o["api_req_map/next"].ResponseReceived += Advanced;
        }

        private bool ShouldRefresh(string mapPoint)
        {
            foreach(string possibleMapPoint in plugin.Settings.MapPoints)
            {
                if (possibleMapPoint.Equals(mapPoint))
                {
                    return true;
                }
            }
            return false;
        }

        private void Advanced(string apiname, dynamic data)
        {
            if (!plugin.Settings.Enabled)
            {
                return;
            }
            CompassData compass = KCDatabase.Instance.Battle.Compass;
            string target = string.Format("{0}-{1}-{2}", compass.MapAreaID, compass.MapInfoID, compass.Destination);
            if (ShouldRefresh(target))
            {
                Logger.Add(2, "沟了 / 疲劳驾驶了，帮你刷新。(" + target + ")");
                formBrowserHost.RefreshBrowser();
            }
        }
    }
}