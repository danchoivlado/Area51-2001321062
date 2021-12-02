using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    public class Elevator
    {
        public List<Button> buttons { get; set; }
        public Floor currentFloor { get; set; }

        public Elevator(List<Button> buttons, Floor floor)
        {
            this.buttons = buttons;
            this.currentFloor = floor;
        }
    }
}
