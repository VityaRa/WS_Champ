using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forma
{
    public class Region
    {
        public int code { get; set; }
        public string name { get; set; }
        public string capital { get; set; }
        public string district { get; set; }
        public Region() { }
        public Region(int code, string name, string capital, string district)
        {
            this.code = code;
            this.name = name;
            this.capital = capital;
            this.district = district;
        }

        public Region(string name, string capital, string district)
        {
            this.name = name;
            this.capital = capital;
            this.district = district;
        }

        public static string SelectRegionCommand()
        {
            return "SELECT * FROM region";  
        }
        public override string ToString()
        {
            return this.code + ". " + this.name + " | " + this.capital + " | " + this.district;
        }

    }
}