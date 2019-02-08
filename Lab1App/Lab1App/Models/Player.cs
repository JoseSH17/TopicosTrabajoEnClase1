using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public BingoElement[,] CardBoardPlayer { get; set; }
        public List<int> MarkedNumbers { get; set; }

        public Player(string name, BingoElement[,] cardBoardPlayer, List<int> markedNumbers)
        {
            Name = name;
            CardBoardPlayer = cardBoardPlayer;
            MarkedNumbers = markedNumbers;
        }

        public Player()
        {
            this.MarkedNumbers = new List<int>();
            this.CardBoardPlayer = new BingoElement[5, 5];
        }
    }
}
