using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2secondtwo
{
    internal class Circulation
    {
        public string title { get; set; }
        public double description { get; set; }

        public Circulation(string title, double description)
        {
            this.title = title;
            this.description = description;
        }
    }
}
