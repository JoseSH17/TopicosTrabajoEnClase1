using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bingo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Bingo.svc or Bingo.svc.cs at the Solution Explorer and start debugging.
    public class Bingo : IBingo
    {
        private WcfLab1.Domain.Specification.Bingo Specification { get; set; }

        public Bingo()
        {
            this.Specification = new WcfLab1.Domain.Specification.Bingo();
        }

        public int GetNumber(List<int> NumberList)
        {
            return Specification.GetNumber(NumberList);
        }

        public bool GetWinner(GameType GameType, BingoElement[,] BingoCardBoard)
        {
            return Specification.CheckWinner(GameType, BingoCardBoard);
        }

        public string ColumnLetter(int CurrentNumber)
        {
            return Specification.GetColumnLetter(CurrentNumber);
        }

    }
}
