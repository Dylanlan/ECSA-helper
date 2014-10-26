using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ECSAHelper
{
    public class ExecutiveName
    {

        public ExecutiveName(string name)
        {
            this.Name = name;
        }

        public ExecutiveName()
        {
            this.Name = "New Position";
        }

        [Category("Executive Position")]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
