using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicObserver.Window;
using ElectronicObserver.Observer;
using ElectronicObserver.Data;
using ElectronicObserver.Utility;
using ElectronicObserver.Utility.Data;

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

        private string ShouldRefreshAtMapPoint(ICollection<string> mapPoints)
        {
            foreach(string possibleMapPoint in plugin.settings.MapPoints)
            {
                if (mapPoints.Contains(possibleMapPoint))
                {
                    return possibleMapPoint;
                }
            }
            return null;
        }

        private bool IsShipDamaged(ShipData ship)
        {
            return (double) ship.HPCurrent / ship.HPMax <= 0.25 &&
                (!ship.AllSlotInstanceMaster.Any(e => e != null ? e.CategoryType == 23 : false));
        }

        private string[] ExistsTaihaShip()
        {
            return KCDatabase.Instance.Fleet.Fleets.Values.Where(f => f.IsInSortie)
                    .SelectMany(f => f.MembersWithoutEscaped.Skip(1))
                    .Where(s => s != null).Where(s => IsShipDamaged(s))
                    .Select(s => string.Format("{0} ({1}/{2})", s.NameWithLevel, s.HPCurrent, s.HPMax))
                    .ToArray();
        }

        private void Advanced(string apiname, dynamic data)
        {
            if (!plugin.settings.Enabled)
            {
                return;
            }

            bool isRefreshing = false;
            string message = null;

            CompassData compass = KCDatabase.Instance.Battle.Compass;

            if (plugin.settings.MapPointEnabled)
            {
                HashSet<string> mapPointAlias = new HashSet<string>();
                mapPointAlias.Add(string.Format("{0}-{1}-{2}", compass.MapAreaID, compass.MapInfoID, compass.Destination));
                string wikiPointName = MapCell2WikiPoint.GetWikiPointName(compass.MapAreaID, compass.MapInfoID, compass.Destination);
                if (!string.IsNullOrEmpty(wikiPointName))
                {
                    mapPointAlias.Add(string.Format("{0}-{1}-{2}", compass.MapAreaID, compass.MapInfoID, wikiPointName));
                }
                string possibleMapPoint = ShouldRefreshAtMapPoint(mapPointAlias);
                if (possibleMapPoint != null)
                {
                    isRefreshing = true;
                    message = "沟了 / 疲劳驾驶了，帮你刷新。(" + possibleMapPoint + ")";
                }
            }

            if (plugin.settings.TaihaEnabled)
            {
                if (compass.EventKind != 0)
                {
                    string[] possibleTaihaShips = ExistsTaihaShip();
                    if (possibleTaihaShips != null && possibleTaihaShips.Length > 0)
                    {
                        isRefreshing = true;
                        message = "大破进击，帮你刷新。(" + string.Join(", ", possibleTaihaShips) + ")";
                    }
                }
            }

            if (isRefreshing)
            {
                Logger.Add(2, message);
                formBrowserHost.RefreshBrowser();
            }
        }
    }
}
