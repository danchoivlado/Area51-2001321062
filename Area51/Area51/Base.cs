using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    public class Base
    {
        public List<Floor> floors { get; set; }
        public Elevator elevator { get; set; }

        public Base(List<Floor> floors, Elevator elevator)
        {
            this.elevator = elevator;
            this.floors = floors;
        }
    }
}
