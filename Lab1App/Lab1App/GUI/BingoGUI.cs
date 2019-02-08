using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;
using WcfLab1.Domain.Respositories;
using Lab1App.GUI;
using Lab1App.Models;

namespace Lab1App.Presentation
{
    public class BingoGUI : IBingoGUI
    {
        #region DisplayPropmts
        public void GrettingsPropmt()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("    Welcome Players to the Best WCF Bingo Ever!!!");
            Console.WriteLine("======================================================");
            Console.WriteLine("               Press ENTER to CONINUE");
            Console.ReadKey();
            Console.Clear();
        }

        public void TimeToPlayPropmt()
        {
            Console.WriteLine("");
            Console.WriteLine("Is time to play!!! (Press ENTER to START)");
            Console.ReadKey();
        }

        public void PressEnterPropmt()
        {
            Console.WriteLine("\nFor the next number, please press ENTER");
            Console.ReadKey();
            Console.Clear();
        }

        public void GoodbyePropmt()
        {
            Console.WriteLine("\nThe game is over :(");
            Console.ReadKey();
        }

        #endregion

        #region Prepare The game

        public string[] GetPlayersNames()
        {
            int numPlayes = 0;
            while (true)
            {
                Console.WriteLine("Write the number of players");
                if (int.TryParse(Console.ReadLine(), out numPlayes))
                {
                    if (numPlayes > 0 && numPlayes <= 10)
                    {
                        string[] names = new string[numPlayes];
                        for (int i = 0; i < numPlayes; i++)
                        {
                            Console.WriteLine("Name of the player #{0}:", i + 1);
                            names[i] = Console.ReadLine();
                        }
                        Console.Clear();
                        return names;
                    }
                    Console.WriteLine("Only can play 1 - 10 people");
                }
                Console.WriteLine("Invalid selection please try again (Press enter)");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public GameType SelectPlayMode()
        {
            while (true)
            {
                Console.WriteLine("Select the game mode");
                Console.WriteLine("1) FullCardboar");
                Console.WriteLine("2) 4 Corners");
                Console.WriteLine("3) H");
                Console.WriteLine("4) X");
                Console.WriteLine("5) O");
                Console.WriteLine("6) U");
                Console.WriteLine("7) P");
                Console.WriteLine("8) A");
                Console.WriteLine("9) E");
                int Resp = int.Parse(Console.ReadLine());

                switch (Resp)
                {
                    case 1:
                        return GameType.Full;
                    case 2:
                        return GameType.FourCorners;
                    case 3:
                        return GameType.H;
                    case 4:
                        return GameType.X;
                    case 5:
                        return GameType.O;
                    case 6:
                        return GameType.U;
                    case 7:
                        return GameType.P;
                    case 8:
                        return GameType.A;
                    case 9:
                        return GameType.E;
                    default:
                        Console.WriteLine("Invalid selection type one of the options");
                        break;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="player"></param>
        public void PrintCardboard(Player player)
        {
            BingoElement CurrentElement;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CurrentElement = player.CardBoardPlayer[i, j];
                    if (CurrentElement.State)
                    {
                        string NewNumber = CurrentElement.Number.Substring(1, 2);

                        Console.Write(" {0} [X]", NewNumber);
                    }
                    else
                    {
                        string ModifiedNumber = CurrentElement.Number;
                        if (!ModifiedNumber.Equals(" XXXXXX"))
                        {
                            if (ModifiedNumber.Substring(1, 2).Contains(" "))
                            {
                                ModifiedNumber = " 0" + ModifiedNumber.Substring(1, 2) + "[ ]";
                            }
                        }
                        Console.Write(ModifiedNumber);
                    }
                }
                Console.WriteLine("");
            }
        }

        #endregion

        #region Make TheMain Task

        public void ShowTheWinner(string PlayerName)
        {
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("      Congratulations {0} you are the winner!!!", PlayerName);
            Console.WriteLine("======================================================");
        }

        public void PrintPlayersAndCardboard(List<Player> PlayersList)
        {
            foreach (var player in PlayersList)
            {
                Console.WriteLine("\n{0}'s Cardboard:", player.Name);
                PrintCardboard(player);
                if (player.MarkedNumbers.Count != 0)
                {
                    PrintMarkedNumbers(player);
                }
            }
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// </summary>
        /// <param name="player"></param>
        public void PrintMarkedNumbers(Player player)
        {
            Console.WriteLine("\n{0}'s Marked Numbers List: {1}", player.Name, string.Join(",", player.MarkedNumbers));
            Console.WriteLine("------------------------------------------------------------------");
        }

        /// <summary>
        /// </summary>
        /// <param name="CurrentNumber"></param>
        /// <param name="PlayersList"></param>
        public void MarkNumber(int CurrentNumber, List<Player> PlayersList)
        {
            foreach (var Player in PlayersList)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!(Player.CardBoardPlayer[i, j].Number.Equals(" XXXXXX")))
                        {
                            if (Convert.ToInt32(Player.CardBoardPlayer[i, j].Number.Substring(1, 2)) == CurrentNumber)
                            {
                                Player.CardBoardPlayer[i, j].State = true;
                                Console.WriteLine("{0}'s number {1}:[{2}][{3}]", Player.Name, CurrentNumber, i + 1, j + 1);
                                Player.MarkedNumbers.Add(CurrentNumber);
                            }
                        }
                    }
                }
            }
        }

        public void ShowNumberList(List<int> NumberList)
        {
            Console.WriteLine("List of the {0} number(s) played:", NumberList.Count);
            Console.WriteLine("{0}", string.Join(",", NumberList));
        }

        #endregion
    }
}
