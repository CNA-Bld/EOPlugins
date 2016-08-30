using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ElectronicObserver.Window;
using ElectronicObserver.Observer;
using ElectronicObserver.Data;
using ElectronicObserver.Utility;
using ElectronicObserver.Utility.Data;

namespace KoebutaRobot
{
    class DropObserver
    {
        #region Singleton

        private static readonly DropObserver instance = new DropObserver();

        public static DropObserver Instance
        {
            get { return instance; }
        }

        #endregion

        private static string shipTemplate = "{0} {1}";
        private static string nothingDropping = "空气";
        private static string mapPointTemplate = "{0}-{1}-{2}";
        private static string infoTemplate = "[{0}] [{1}] {2} {3}";
        private static string urlTemplate = "http://{0}/?target={1}&id={2}&msg={3}";

        private Plugin plugin;

        public void Initialize(Plugin plugin)
        {
            this.plugin = plugin;

            APIObserver o = APIObserver.Instance;
            o["api_req_sortie/battleresult"].ResponseReceived += BattleResultGet;
        }

        private bool ShouldReport(string mapPoint)
        {
            if (!plugin.settings.Enabled) return false;
            return !plugin.settings.ReportOnlyOnSelectedPoints || plugin.settings.SelectedPoints.Split(',').Any(mapPoint.Equals);
        }

        private void BattleResultGet(string apiname, dynamic data)
        {
            string newShip = nothingDropping;

            int shipId = KCDatabase.Instance.Battle.Result.DroppedShipID;
            if (shipId != -1)
            {
                ShipDataMaster ship = KCDatabase.Instance.MasterShips[shipId];
                newShip = String.Format(shipTemplate, ship.ShipTypeName, ship.Name);
            }

            string playerName = KCDatabase.Instance.Admiral.AdmiralName;

            int mapAreaId = KCDatabase.Instance.Battle.Compass.MapAreaID;
            int mapInfoId = KCDatabase.Instance.Battle.Compass.MapInfoID;
            int destination = KCDatabase.Instance.Battle.Compass.Destination;
            string mapPoint = String.Format(mapPointTemplate, mapAreaId, mapInfoId, destination);

            if (!ShouldReport(mapPoint))
            {
                return;
            }

            string battleResult = KCDatabase.Instance.Battle.Result.Rank;
            
            string info = String.Format(infoTemplate, playerName, mapPoint, battleResult,
                newShip);

            string url = String.Format(urlTemplate, plugin.settings.Server, plugin.settings.Target,
                plugin.settings.Tid, info);

            WebRequest.Create(url).GetResponse();
        }
    }
}
