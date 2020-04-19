using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS_Environmental_Analysis
{
   public class Dupla
    {
        String filter;
        String output;

        public Dupla(String Filter, String Output)
        {
            this.Filter = Filter;
            this.Output = Output;
        }

        public string Filter { get => filter; set => filter = value; }
        public string Output { get => output; set => output = value; }
    }
}
