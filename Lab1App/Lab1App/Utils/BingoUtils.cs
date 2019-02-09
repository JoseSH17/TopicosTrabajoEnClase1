using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1App.Models;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Utils
{
    public class BingoUtils : IBingoUtils
    {
    
       // Metodo que crea la lista de jugadores, sus datos y su respectivo carton de juego
        public List<Jugador> CrearJugador(string[] NombreJugadores)
        {
            List<Jugador> ListaJugadores = new List<Jugador>();
            for (int i = 0; i < NombreJugadores.Length; i++)
            {
                Jugador NuevoJugador = new Jugador();
                NuevoJugador.ID = i + 1;
                NuevoJugador.Nombre = NombreJugadores[i];
                NuevoJugador.CartonDelJugador = InicializarCarton(NuevoJugador.CartonDelJugador);
                ListaJugadores.Add(NuevoJugador);
            }
            return ListaJugadores;
        }
        
        // Metodo que asigna cada letra de la palabra bingo a una columna en especifico
        public BingoRepo[,] InicializarCarton(BingoRepo[,] m)
        {
            char[] cols = new char[]
            {
                'B','I','N','G','O'
            };

            for (int i = 0; i < cols.Length; i++)
            {
                LlenarColumnas(cols[i], m);
            }

            return m;
        }

        /// <resumen>
        /// LLena cada columna con un valor en especifico 
        /// </resumen>
        /// <parametro1="CurrentColumn"></param>
        /// <parametro2="m"></param>
        /// <returns></returns>
        public BingoRepo[,] LlenarColumnas(char ColumnaActual, BingoRepo[,] m)
        {
            int IndiceColumna = 0;
            int PrimerNumero = 0;
            int UltimoNumero = 0;

            switch (ColumnaActual)
            {
                case 'B':
                    IndiceColumna = 0;
                    PrimerNumero = 1;
                    UltimoNumero = 15;
                    break;
                case 'I':
                    IndiceColumna = 1;
                    PrimerNumero = 16;
                    UltimoNumero = 30;
                    break;
                case 'N':
                    IndiceColumna = 2;
                    PrimerNumero = 31;
                    UltimoNumero = 45;
                    break;
                case 'G':
                    IndiceColumna = 3;
                    PrimerNumero = 46;
                    UltimoNumero = 60;
                    break;
                case 'O':
                    IndiceColumna = 4;
                    PrimerNumero = 61;
                    UltimoNumero = 75;
                    break;
                default:
                    return null;
            }

            List<int> NumerosSeleccionados = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (ColumnaActual == 'N' && i == 2)
                {
                    m[i, IndiceColumna] = new BingoRepo(" XXXXXX", false);
                }
                else
                {
                    int NumeroActual = CalcularNumero(PrimerNumero, UltimoNumero);
                    while (NumerosSeleccionados.Contains(NumeroActual))
                    {
                        NumeroActual = CalcularNumero(PrimerNumero, UltimoNumero);
                    }
                    NumerosSeleccionados.Add(NumeroActual);
                    m[i, IndiceColumna] = new BingoRepo(" " + NumeroActual + " [ ]", false);
                }
            }
            return m;
        }

        public int CalcularNumero(int PrimerNumero, int UltimoNumero)
        {
            Random rnd = new Random();
            return rnd.Next(PrimerNumero, UltimoNumero + 1);
        }
    }
}
