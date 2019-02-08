using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;

namespace Lab1App.Models
{
    public class Game
    {
        public GameType GameMode { get; set; }
        public List<Player> PlayerList { get; set; }

        public Game (GameType _GameMode, List<Player> PlayerList)
        {
            this.GameMode = _GameMode;
            this.PlayerList = PlayerList;
        }
    }
}
