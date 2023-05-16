using RPG_OOP.classy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_OOP.Source_codes.Gamemanager
{
    //Tenhle bude pohybovat hrou, ví o svých datech a s nimi pracuje, endpoint
    public class GameService
    {
        public GameRepository gameRepository { get; set; }
        public GameService()
        {
            this.gameRepository = new GameRepository();  
        }
        public void SetPlayer(string name)
        {
            gameRepository.player = new Player(name);
            gameRepository.startGame = false;
        }
    }
}
