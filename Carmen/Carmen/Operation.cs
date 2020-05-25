using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmen
{
    public class Operation
    {
        public string LeftSide { get; set; }
        public string RightSide { get; set; }
        public OperationType OperationType { get; set; }
        public Operation()
        {
            this.RightSide = string.Empty;
            this.LeftSide = string.Empty;
        }
    }
}
