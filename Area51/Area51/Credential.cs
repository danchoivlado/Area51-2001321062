using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    public class Credential
    {
        public string securityLevelName { get; set; }
        public List<Floor> accessFlors { get; set; }

        public Credential(string securityLevelName, List<Floor> accessFlors)
        {
            this.securityLevelName = securityLevelName;
            this.accessFlors = accessFlors;
        }
    }
}
