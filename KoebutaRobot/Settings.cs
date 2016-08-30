using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoebutaRobot
{
    public class Settings
    {
        public bool Enabled { get; set; } = true;
        public string Server { get; set; } = "localhost:8081";
        public string Target { get; set; }
        public string Tid { get; set; }
        public bool ReportOnlyOnSelectedPoints { get; set; } = false;
        public string SelectedPoints { get; set; }
    }
}
