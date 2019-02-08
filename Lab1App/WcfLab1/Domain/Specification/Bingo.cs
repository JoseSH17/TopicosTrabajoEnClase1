using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;
using WcfLab1.Domain.Services;

namespace WcfLab1.Domain.Specification
{
    public class Bingo
    {
        private Domain.Actions.Bingo BingoAction { get; set; }


        public Bingo()
        {
            BingoAction = new Domain.Actions.Bingo();
        }

        /// <summary>
        /// Return a number betwen 1 - 75 and fill a list
        /// </summary>
        /// <param name="NumberList"> List of numbers to play </param>
        /// <returns></returns>
        public int GetNumber(List<int> NumberList)
        {
            int CurrentNumber = 0;
            while (NumberList.Count < 75)
            {
                CurrentNumber = BingoAction.CalculateNumber(1, 75);
                if (!NumberList.Contains(CurrentNumber))
                {
                    return CurrentNumber;
                }
            }
            return CurrentNumber;
        }

        public bool CheckWinner(GameType gameType, BingoElement[,] BingoCardBoard)
        {
            string[,] WinnerPatter = BingoAction.GetWinnerPattern(gameType);
            return BingoAction.GetTheWinner(WinnerPatter, BingoCardBoard);
        }

        public string GetColumnLetter(int CurrentNumber)
        {
            return BingoAction.GetBingoColumnLetter(CurrentNumber);
        }



    }
}