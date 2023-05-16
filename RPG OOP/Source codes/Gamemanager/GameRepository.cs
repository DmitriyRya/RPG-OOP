using RPG_OOP.classy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_OOP.Source_codes.Gamemanager
{
    //Třída obsahuje data, zde si je bude pamatovat
    public class GameRepository
    {
        public Config config { get; set; }
        public Entity enemy;
        public Player player;
        public bool startGame { get; set; }
        public GameRepository()
        {
            this.config = new Config();
            this.startGame = true;
        }
        
    }
}
