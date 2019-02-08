using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBingo" in both code and config file together.
    public enum GameType
    {
        Full,FourCorners,H,X,O,U,P,A,E
    }

    [ServiceContract]
    public interface IBingo
    {
        [OperationContract]
        int GetNumber(List<int> NumberList);
        bool GetWinner(GameType GameType, BingoElement[,] BingoCardBoard);
    }
}
