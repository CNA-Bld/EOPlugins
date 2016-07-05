using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldDriver
{
    public class Settings
    {
        public bool Enabled { get; set; } = true;
        public bool MapPointEnabled { get; set; } = true;
        public List<string> MapPoints { get; set; } = new[] { "3-2-B", "5-1-A", "5-1-F" }.ToList();
        public bool TaihaEnabled { get; set; } = false;
    }
}
