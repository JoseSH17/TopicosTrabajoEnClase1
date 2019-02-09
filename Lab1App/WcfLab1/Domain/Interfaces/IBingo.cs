using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{
    // Interface tipo de juego del bingo
    public enum GameType
    {
        Full,FourCorners,H,X,O,U,P,A,E
    }
   // llama a los metodos obtenernumeros para empezar a asignar numeros aleatorios entre 1 y 75 y obtiene el ganador invocando al metodo obtener ganador
    [ServiceContract]
    public interface IBingo
    {
        [OperationContract]
        int GetNumber(List<int> NumberList);
        bool GetWinner(GameType GameType, BingoElement[,] BingoCardBoard);
    }
}
