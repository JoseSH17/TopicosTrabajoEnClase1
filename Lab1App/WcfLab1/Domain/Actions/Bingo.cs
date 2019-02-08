using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;
using WcfLab1.Domain.Services;

namespace WcfLab1.Domain.Actions
{
    public class Bingo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentNumber"></param>
        /// <returns></returns>
        public string GetBingoColumnLetter(int CurrentNumber)
        {
            if (CurrentNumber >= 1 && CurrentNumber <= 15)
            {
                return "B";
            }
            else if (CurrentNumber >= 16 && CurrentNumber <= 30)
            {
                return "I";
            }
            else if (CurrentNumber >= 31 && CurrentNumber <= 45)
            {
                return "N";
            }
            else if (CurrentNumber >= 46 && CurrentNumber <= 60)
            {
                return "G";
            }
            else if (CurrentNumber >= 61 && CurrentNumber <= 75)
            {
                return "O";
            }
            return String.Empty;
        }

        /// <summary>
        /// Fill all the matrix with the numbers
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Ony Get a random number that its inside of this range
        /// </summary>
        /// <param name="FistNumber"></param>
        /// <param name="LastNumber"></param>
        /// <returns></returns>
        public int CalculateNumber(int FistNumber, int LastNumber)
        {
            Random rnd = new Random();
            return rnd.Next(FistNumber, LastNumber + 1);
        }

        public string[,] GetWinnerPattern(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Full:
                    return patternFull();
                case GameType.FourCorners:
                    return pattern4Corners();
                case GameType.H:
                    return patternH();
                case GameType.X:
                    return patternX();
                case GameType.O:
                    return patternO();
                case GameType.U:
                    return patternU();
                case GameType.P:
                    return patternP();
                case GameType.A:
                    return patternA();
                case GameType.E:
                    return patternE();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ElementList"></param>
        /// <returns></returns>
        public int CountOfElement(string element, string[,] ElementList)
        {
            int NumElement = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ElementList[i, j] != null)
                    {
                        if (ElementList[i, j].Equals(element))
                        {
                            NumElement++;
                        }
                    }
                }
            }
            return NumElement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WinnerPattern"></param>
        /// <param name="PlayersList"></param>
        /// <returns></returns>
        public bool GetTheWinner(string[,] WinnerPattern, BingoElement[,] cardBoardPlayer)
        {
            int xPattern = -1;
            int xPlayer = 0;
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (WinnerPattern[f, c] != null)
                    {
                        xPattern++;
                        if (cardBoardPlayer[f, c].State == true)
                            xPlayer++;
                    }
                }
            }
            if (xPattern == xPlayer)
            {
                return true;
            }
            return false;
        }

        #region Patterns

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternFull()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c <= 4; c++)
                {
                    patron[f, c] = "X";
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] pattern4Corners()
        {
            string[,] patron = new string[5, 5];
            patron[0, 0] = "X"; patron[0, 4] = "X";
            patron[2, 2] = "XXXXXX";
            patron[4, 0] = "X"; patron[4, 4] = "X";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternH()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (c == 0 || c == 4)
                        patron[f, c] = "X";
                    else
                    {
                        if (f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternX()
        {
            string[,] patron = new string[5, 5];
            patron[0, 0] = "X"; patron[0, 4] = "X";
            patron[1, 1] = "X"; patron[1, 3] = "X";
            patron[2, 2] = "XXXXXX";
            patron[3, 1] = "X"; patron[3, 3] = "X";
            patron[4, 0] = "X"; patron[4, 4] = "X";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternO()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (f == 0 || f == 4)
                    {
                        if (c == 1 || c == 2 || c == 3)
                            patron[f, c] = "X";
                    }
                    else
                    {
                        if (c == 0 || c == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternU()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (f == 4)
                    {
                        if (c == 1 || c == 2 || c == 3)
                            patron[f, c] = "X";
                    }
                    else
                    {
                        if (c == 0 || c == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternP()
        {
            string[,] patron = new string[5, 5];
            for (int c = 0; c < 3; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0)
                        patron[f, c] = "X";
                    if (c == 1)
                    {
                        if (f == 0 || f == 2)
                            patron[f, c] = "X";
                    }
                    if (c == 2)
                    {
                        if (f == 0 || f == 1 || f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternA()
        {
            string[,] patron = new string[5, 5];
            patron[0, 2] = "X";
            for (int c = 0; c < 5; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0 || c == 4)
                    {
                        patron[f, c] = "X";
                    }
                    else
                    {
                        if (f == 0 || f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[,] patternE()
        {
            string[,] patron = new string[5, 5];
            patron[0, 2] = "X";
            for (int c = 0; c < 5; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0)
                    {
                        patron[f, c] = "X";
                    }
                    else
                    {
                        if (f == 0 || f == 2 || f == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        #endregion
    }
}
