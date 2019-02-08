using Lab1App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Utils
{
    public interface IBingoUtils
    {
        List<Player> CreatePlayer(string[] userNames);
        BingoElement[,] InitializeCardboard(BingoElement[,] m);
        BingoElement[,] FillColumn(char CurrentColumn, BingoElement[,] m);
        int CalculateNumber(int FistNumber, int LastNumber);
    }
}
