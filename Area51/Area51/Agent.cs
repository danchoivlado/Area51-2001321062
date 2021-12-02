using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    public class Agent
    {
        public string name { get; set; }
        public Credential credential { get; set; }

        public Agent(string name, Credential credential)
        {
            this.name = name;
            this.credential = credential;
        }
    }
}
