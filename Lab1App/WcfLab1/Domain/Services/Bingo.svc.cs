using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{
    
    public class Bingo : IBingo
    {
    
    
        private WcfLab1.Domain.Specification.Bingo Specification { get; set; }

       // Matriz de Cartones
        public Bingo()
        {
            this.Specification = new WcfLab1.Domain.Specification.Bingo();
        }
     // Obtiene los numeros aleatorios entre 1 y 75 para llenar el cart[on
        public int GetNumber(List<int> NumberList)
        {
            return Specification.GetNumber(NumberList);
        }
        // Verifica el ganador
        public bool GetWinner(GameType GameType, BingoElement[,] BingoCardBoard)
        {
            return Specification.CheckWinner(GameType, BingoCardBoard);
        }
        // Asgina una letra de la palabra BINGO a una columna especifica
        public string ColumnLetter(int CurrentNumber)
        {
            return Specification.GetColumnLetter(CurrentNumber);
        }

    }
}
