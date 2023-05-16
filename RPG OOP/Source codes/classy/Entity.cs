using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_OOP.classy;
using RPG_OOP.Source_codes.Gamemanager;

namespace RPG_OOP.classy
{
    public class Entity
    {
       public string Name {  get; set; }
       public int Hp { get; set; }
       public int Dmg { get; set; }
       public bool Friendly { get; set; }

        public int Reward { get; set; }


        public Entity(string name, int hp, int dmg, bool friendly, int reward)
        {
            Name = name;
            Hp = hp;
            Dmg = dmg;
            Friendly = friendly;
            Reward = reward;
        }
        public string EntityFeedback()
        {
            return "Stav nepřítele " + Name + " se zbyvájícími " + Hp + " HP.";
        }
    }
}
