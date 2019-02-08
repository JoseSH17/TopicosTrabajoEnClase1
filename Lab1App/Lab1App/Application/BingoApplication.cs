using Lab1App.GUI;
using Lab1App.Models;
using Lab1App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;

namespace Lab1App.Application
{
    public class BingoApplication
    {
        private readonly IBingoUtils utils;
        private readonly IBingoGUI bingoGUI;
        private readonly IBingo WFCBingo;

        public BingoApplication(IBingoUtils _utils, IBingoGUI _bingoGUI, IBingo _WFCBingo)
        {
            this.utils = _utils;
            this.bingoGUI = _bingoGUI;
            this.WFCBingo = _WFCBingo;
        }

        /// <summary>
        /// Ask for the Number of players and their data and a game mode
        /// </summary>
        /// <returns></returns>
        public Game PrepareTheGame()
        {
            bingoGUI.GrettingsPropmt();
            string[] playersNames = bingoGUI.GetPlayersNames();
            List<Player> PlayerList = utils.CreatePlayer(playersNames);
            bingoGUI.PrintPlayersAndCardboard(PlayerList);
            return new Game(bingoGUI.SelectPlayMode(), PlayerList);
        }

        public string MakeTheMainTask(Game game)
        {
            List<int> NumberList = new List<int>();
            int CurrentNumber = 0;
            bool BingoResult = false;
            while (!BingoResult)
            {
                bingoGUI.PressEnterPropmt();
                CurrentNumber = WFCBingo.GetNumber(NumberList);
                NumberList.Add(CurrentNumber);
                bingoGUI.ShowNumberList(NumberList);
                foreach (var player in game.PlayerList)
                {
                    if (WFCBingo.GetWinner(game.GameMode, player.CardBoardPlayer))
                    {
                        bingoGUI.PrintPlayersAndCardboard(game.PlayerList);
                        return player.Name;
                    }
                }
                bingoGUI.MarkNumber(CurrentNumber, game.PlayerList);
                bingoGUI.PrintPlayersAndCardboard(game.PlayerList);
            }
            return null;
        }

        /// <summary>
        /// Execute the main action
        /// </summary>
        public void PlayBingo()
        {
            var game = PrepareTheGame();
            bingoGUI.TimeToPlayPropmt();
            bingoGUI.ShowTheWinner(MakeTheMainTask(game));
            bingoGUI.GoodbyePropmt();
        }




    }
}
