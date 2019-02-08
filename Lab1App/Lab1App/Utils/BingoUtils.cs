using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1App.Models;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Utils
{
    public class BingoUtils : IBingoUtils
    {
        public List<Player> CreatePlayer(string[] PlayersNames)
        {
            List<Player> PlayersList = new List<Player>();
            for (int i = 0; i < PlayersNames.Length; i++)
            {
                Player NewPlayer = new Player();
                NewPlayer.ID = i + 1;
                NewPlayer.Name = PlayersNames[i];
                NewPlayer.CardBoardPlayer = InitializeCardboard(NewPlayer.CardBoardPlayer);
                PlayersList.Add(NewPlayer);
            }
            return PlayersList;
        }

        public BingoElement[,] InitializeCardboard(BingoElement[,] m)
        {
            char[] Columns = new char[]
            {
                'B','I','N','G','O'
            };

            for (int i = 0; i < Columns.Length; i++)
            {
                FillColumn(Columns[i], m);
            }

            return m;
        }

        /// <summary>
        /// Fill each column with the value 
        /// </summary>
        /// <param name="CurrentColumn"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public BingoElement[,] FillColumn(char CurrentColumn, BingoElement[,] m)
        {
            int ColumnIndex = 0;
            int FistNumber = 0;
            int LastNumber = 0;

            switch (CurrentColumn)
            {
                case 'B':
                    ColumnIndex = 0;
                    FistNumber = 1;
                    LastNumber = 15;
                    break;
                case 'I':
                    ColumnIndex = 1;
                    FistNumber = 16;
                    LastNumber = 30;
                    break;
                case 'N':
                    ColumnIndex = 2;
                    FistNumber = 31;
                    LastNumber = 45;
                    break;
                case 'G':
                    ColumnIndex = 3;
                    FistNumber = 46;
                    LastNumber = 60;
                    break;
                case 'O':
                    ColumnIndex = 4;
                    FistNumber = 61;
                    LastNumber = 75;
                    break;
                default:
                    return null;
            }

            List<int> SelectedNumbers = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (CurrentColumn == 'N' && i == 2)
                {
                    m[i, ColumnIndex] = new BingoElement(" XXXXXX", false);
                }
                else
                {
                    int CurrentNumber = CalculateNumber(FistNumber, LastNumber);
                    while (SelectedNumbers.Contains(CurrentNumber))
                    {
                        CurrentNumber = CalculateNumber(FistNumber, LastNumber);
                    }
                    SelectedNumbers.Add(CurrentNumber);
                    m[i, ColumnIndex] = new BingoElement(" " + CurrentNumber + " [ ]", false);
                }
            }
            return m;
        }

        public int CalculateNumber(int FistNumber, int LastNumber)
        {
            Random rnd = new Random();
            return rnd.Next(FistNumber, LastNumber + 1);
        }
    }
}
