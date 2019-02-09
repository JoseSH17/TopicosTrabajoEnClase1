using System.Collections.Generic;
using WcfLab1.Domain.Respositories;
using WcfLab1.Domain.Services;

namespace WcfLab1.Domain.Specification
{
    public class Bingo
    {
        private Actions.Bingo Accion { get; set; }


        public Bingo()
        {
            Accion = new Actions.Bingo();
        }

        /// <summary>
        /// Retorna un numero entre 1 y 75 y llena la lista
        /// </summary>
        /// <parametro1 ="ListaNumeros"> Lista de numeros para jugar </param>
        /// <returns></returns>
        public int ObtenerNumero(List<int> ListaNumeros)
        {
            int NumeroActual = 0;
            while (ListaNumeros.Count < 75)
            {
                NumeroActual = Accion.CalcularNumero(1, 75);
                if (!ListaNumeros.Contains(NumeroActual))
                {
                    return NumeroActual;
                }
            }
            return NumeroActual;
        }

        public bool VerificarGanador(ModoDeJuego modoJuego, BingoRepo[,] cartonBingo)
        {
            string[,] PatronGanador = Accion.ObtenerPatronGanador(modoJuego);
            return Accion.ObtenerGanador(PatronGanador, cartonBingo);
        }

        public string ObtenerLetraColumna(int NumeroActual)
        {
            return Accion.ObtenerLetraDeColumnaBingo(NumeroActual);
        }



    }
}
