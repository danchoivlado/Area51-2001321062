using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    public class Floor
    {
        public string name { get; set; }
        public Button button { get; set; }

        public Floor(string name, Button button)
        {
            this.name = name;
            this.button = button;
        }
    }
}
