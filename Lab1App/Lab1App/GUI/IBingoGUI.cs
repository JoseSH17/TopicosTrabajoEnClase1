using Lab1App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;

namespace Lab1App.GUI
{
    public interface IBingoGUI
    {
        string[] GetPlayersNames();
        GameType SelectPlayMode();
        void PrintPlayersAndCardboard(List<Player> PlayersList);
        void PrintCardboard(Player player);
        void MarkNumber(int CurrentNumber, List<Player> PlayersList);
        void PrintMarkedNumbers(Player player);
        void ShowNumberList(List<int> NumberList);
        void ShowTheWinner(string PlayerName);
        void GrettingsPropmt();
        void GoodbyePropmt();
        void TimeToPlayPropmt();
        void PressEnterPropmt();
    }
}
