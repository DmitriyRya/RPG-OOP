using RPG_OOP.classy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_OOP.Source_codes
{
    //Do mně zapisuj globální hodnoty, lépe se managují a jsou přístupné
    public class Config
    {
        //Přístup přes get a set; je nastavená jako public, libovolně upravitelné
        public bool comb { get; set; }
        public string meno { get; set; }
        public bool heavy { get; set; }
        public bool kro { get; set; }
        public bool utek { get; set; }
        public Config()
        {
            this.comb = false;

            this.meno = "";

            this.heavy = true;

            this.kro = false;

            this.utek = true;
        }
    }
}
