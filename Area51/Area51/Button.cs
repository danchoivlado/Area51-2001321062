using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    public class Button
    {
        public string toFloorName { get; set; }
        public bool Pressed { get; set; }

        public Button(string floorName)
        {
            this.toFloorName = floorName;
        }
    }
}
