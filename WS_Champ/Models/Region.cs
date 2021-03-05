using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Champ.Models
{
    public class Region
    {
        public int code { get; set; }
        public string name { get; set; }
        public string capital { get; set; }
        public string district { get; set; }
        public Region() { }
        public Region(int code, string name, string capital, string district) {
            this.code = code;
            this.name = name;
            this.capital = capital;
            this.district = district;
        }

        public static string SelectRegionCommand ()
        {
            return "SELECT * FROM region";
        }
    }
}