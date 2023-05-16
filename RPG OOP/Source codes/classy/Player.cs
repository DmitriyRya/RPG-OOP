using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_OOP.classy;

namespace RPG_OOP.classy
{
    public class Player
    {
        //Jména podle "Camel case" viz: https://blog.boot.dev/clean-code/casings-in-coding/
        //dogName
        //dog_name
        //DOG_NAME
        //dog-name
        public string name { get; set; }
        public int hp { get; set; }
        public int dmg { get; set; }
        public bool friendly { get; set; }
        public int stepCounter { get; set; }
        public double multiplier { get; set; }
        //Můžeme udělat inventory třídu
        public List<Item> items = new List<Item>();
        public int coins { get; set; }
        //Když budeme vědět všechny parametry tak ho vytvoříme takto, ale potřebujeme blank playera
        public Player(string name, int hp, int dmg, bool friendly, int stepcounter, double multiplier, List<Item> items, int coiny)
        {
            this.name = name;
            this.hp = hp;
            this.dmg = dmg;
            this.friendly = friendly;
            this.stepCounter = stepcounter;
            this.multiplier = multiplier;
            this.items = items;
            this.coins = coiny;
        }
        //Blank player se základními parametry
        public Player(string name)
        {
            this.name = name;
            this.hp = 20;
            this.dmg = 2;
            this.friendly = true;
            this.stepCounter = 1;
            this.multiplier = 1.5;
            this.items = new List<Item>();
            this.coins = 0;
        }
        //Chceme feedback, na damage, zaobalený do textu
        public string PlayerFeedbackOnDamage()
        {
            return "Udělil jsi " + dmg;
        }
    }
}
