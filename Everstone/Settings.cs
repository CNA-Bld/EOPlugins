using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstone
{
    public class Settings
    {
        public bool Enabled { get; set; } = true;
        public List<string> ProtectedShips { get; set; } = new List<string>();
    }
}
