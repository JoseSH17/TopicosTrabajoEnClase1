using System.Collections.Generic;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{

    public class Bingo : IBingo
    {
    
    
        private Specification.Bingo Especificacion { get; set; }

       // Matriz de Cartones
        public Bingo()
        {
            this.Especificacion = new Specification.Bingo();
        }
     // Obtiene los numeros aleatorios entre 1 y 75 para llenar el cart[on
        public int ObtenerNumero(List<int> ListaNumeros)
        {
            return Especificacion.ObtenerNumero(ListaNumeros);
        }
        // Verifica el ganador
        public bool ObtenerGanador(ModoDeJuego ModoJuego, BingoRepo[,] CartonBingo)
        {
            return Especificacion.VerificarGanador(ModoJuego, CartonBingo);
        }
        // Asgina una letra de la palabra BINGO a una columna especifica
        public string ColumnLetter(int NumeroActual)
        {
            return Especificacion.ObtenerLetraColumna(NumeroActual);
        }

    }
}
