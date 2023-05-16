using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_OOP.classy;

namespace RPG_OOP.classy
{
    public class Item
    {
        public string Name { get; set; }
        public int Dmg {get;set;}
        public int Shield {get;set;} 
        public bool Tradeble { get;set;}
        public int Value { get;set;}
        public int HpRec { get;set;}

        public Item(string name, int dmg, int shield, bool tradeble, int value, int hpRec)
        {
            Name = name;
            Dmg = dmg;
            Shield = shield;
            Tradeble = tradeble;
            Value = value;
            HpRec = hpRec;
        }


    }
}
