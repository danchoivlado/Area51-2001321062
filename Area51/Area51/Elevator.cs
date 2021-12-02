using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    public class Elevator
    {
        public List<Button> buttons { get; set; }
        public Floor currentFloor { get; set; }
        public bool occupied { get; set; }

        public Elevator(List<Button> buttons, Floor floor)
        {
            this.buttons = buttons;
            this.currentFloor = floor; 
        }
    

        public bool Enter(Credential credential, Floor destinationFloor)
        {

            if (!credential.accessFlors.Any(x => x.name == destinationFloor.name))
            {
                return false;
            }

            this.occupied = true;
            Thread.Sleep(1000);
            this.occupied = false;

            return true;
        }

        public void CallElevatorOnFloor(Floor floor)
        {
            if (!this.occupied)
            {
                Thread.Sleep(1000);
                this.currentFloor = floor;
            }
        }
    }
}
