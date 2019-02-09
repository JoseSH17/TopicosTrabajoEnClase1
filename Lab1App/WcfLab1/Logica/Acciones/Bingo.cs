using System;
using System.Collections.Generic;
using WcfLab1.Domain.Respositories;
using WcfLab1.Domain.Services;

namespace WcfLab1.Domain.Actions
{
    public class Bingo
    {
        /// <resumen>
        /// Metodo que genera cada letra de la palabra bingo en su respectiva columna
        /// </resumen>
        /// <parametro1="CurrentNumber"></param>
        /// <returns></returns>
        public string ObtenerLetraDeColumnaBingo(int NumeroActual)
        {
            if (NumeroActual >= 1 && NumeroActual <= 15)
            {
                return "B";
            }
            else if (NumeroActual >= 16 && NumeroActual <= 30)
            {
                return "I";
            }
            else if (NumeroActual >= 31 && NumeroActual <= 45)
            {
                return "N";
            }
            else if (NumeroActual >= 46 && NumeroActual <= 60)
            {
                return "G";
            }
            else if (NumeroActual >= 61 && NumeroActual <= 75)
            {
                return "O";
            }
            return String.Empty;
        }
        /// <resumen>
        /// Rellena toda la matriz con los numeros
        /// </resumen>
        /// <nombre del parametro="m"></param>
        /// retorna m

        public BingoRepo[,] InicializarCarton(BingoRepo[,] m)
        {
            char[] cols = new char[]
            {
                'B','I','N','G','O'
            };

            for (int i = 0; i < cols.Length; i++)
            {
                FillColumn(cols[i], m);
            }

            return m;
        }

        /// <resumen>
        /// LLena cada columna con su respectivo valor
        /// </resumen>
        /// <nombre del parametro 1="ColumnaActual"></param>
        /// <parametro2="m"></param>
        /// <returns></returns>
        public BingoRepo[,] FillColumn(char ColumnaActual, BingoRepo[,] m)
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

            List<int> NumerosFavorecidos = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (ColumnaActual == 'N' && i == 2)
                {
                    m[i, IndiceColumna] = new BingoRepo(" XXXXXX", false);
                }
                else
                {
                    int NumeroActual = CalcularNumero(PrimerNumero, UltimoNumero);
                    while (NumerosFavorecidos.Contains(NumeroActual))
                    {
                        NumeroActual = CalcularNumero(PrimerNumero, UltimoNumero);
                    }
                    NumerosFavorecidos.Add(NumeroActual);
                    m[i, IndiceColumna] = new BingoRepo(" " + NumeroActual + " [ ]", false);
                }
            }
            return m;
        }

        /// <resumen>
        /// calcula  numeros aleatorios dentro del rango especifico
        /// </resumen>
        /// <parametro1="PrimerNumero"></param>
        /// <parametro2="UltimoNumero"></param>
        /// retorna el respectivo numero
        public int CalcularNumero(int PrimerNumero, int UltimoNumero)
        {
            Random rnd = new Random();
            return rnd.Next(PrimerNumero, UltimoNumero + 1);
        }

        public string[,] ObtenerPatronGanador(ModoDeJuego modoJuego)
        {
            switch (modoJuego)
            {
                case ModoDeJuego.CartonLleno:
                    return LLenarPatron();
                case ModoDeJuego.CuatroEsquinas:
                    return patronCuatroEsquinas();
                case ModoDeJuego.H:
                    return patronH();
                case ModoDeJuego.X:
                    return patronX();
                case ModoDeJuego.O:
                    return patronO();
                case ModoDeJuego.U:
                    return patronU();
                case ModoDeJuego.P:
                    return patronP();
                case ModoDeJuego.A:
                    return patronA();
                case ModoDeJuego.E:
                    return patronE();
                default:
                    return null;
            }
        }

        /// <resumen>
        /// Conteo de elementos dentro de la matriz de numeros
        /// </resumen>
        /// <parametro 1="elemento"></param>
        /// <parametro 2="ListaElementos"></param>
        /// <returns></returns>
        public int ConteoDeElementos(string elemento, string[,] ListaElementos)
        {
            int elNum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ListaElementos[i, j] != null)
                    {
                        if (ListaElementos[i, j].Equals(elemento))
                        {
                            elNum++;
                        }
                    }
                }
            }
            return elNum;
        }

        /// <summary>
        /// Obtener el ganador de un juego en especifico
        /// </summary>
        /// <parametro1="PatronGanador"></param>
        /// <parametro2  ="cartonDeJugador"></param>
        /// <returns>gano o perdio</returns>
        public bool ObtenerGanador(string[,] PatronGanador, BingoRepo[,] cartonDeJugador)
        {
            int xPatron = -1;
            int xJugador = 0;
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (PatronGanador[f, c] != null)
                    {
                        xPatron++;
                        if (cartonDeJugador[f, c].Estado == true)
                            xJugador++;
                    }
                }
            }
            if (xPatron == xJugador)
            {
                return true;
            }
            return false;
        }

        #region Patrones

        /// <resumen>
        /// Metodo para juego de carton lleno
        /// </resumen>
        /// <returns>carton listo para jugar</returns>
        public string[,] LLenarPatron()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c <= 4; c++)
                {
                    patron[f, c] = "X";
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <resumen>
        /// Metodo para juego 4 esquinas
        /// </resumen>
        /// <returns>carton listo para jugar</returns>
        public string[,] patronCuatroEsquinas()
        {
            string[,] patron = new string[5, 5];
            patron[0, 0] = "X"; patron[0, 4] = "X";
            patron[2, 2] = "XXXXXX";
            patron[4, 0] = "X"; patron[4, 4] = "X";
            return patron;
        }

        /// <summary>
        /// Metodo para jugar letra H
        /// </summary>
        /// <returns>Carton listo para jugar</returns>
        public string[,] patronH()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (c == 0 || c == 4)
                        patron[f, c] = "X";
                    else
                    {
                        if (f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <resumen>
        /// Metodo para juego de Letra X
        /// </resumen>
        /// <returns>Carton listo para jugar</returns>
        public string[,] patronX()
        {
            string[,] patron = new string[5, 5];
            patron[0, 0] = "X"; patron[0, 4] = "X";
            patron[1, 1] = "X"; patron[1, 3] = "X";
            patron[2, 2] = "XXXXXX";
            patron[3, 1] = "X"; patron[3, 3] = "X";
            patron[4, 0] = "X"; patron[4, 4] = "X";
            return patron;
        }

        /// <resumen>
        /// Metodo para juego de Letra O
        /// </resumen>
        /// <returns>patron listo para jugar</returns>
        public string[,] patronO()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (f == 0 || f == 4)
                    {
                        if (c == 1 || c == 2 || c == 3)
                            patron[f, c] = "X";
                    }
                    else
                    {
                        if (c == 0 || c == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <resumen>
        /// Metodo para jugar Letra U
        /// </resumen>
        /// <returns>Carton listo para jugar</returns>
        public string[,] patronU()
        {
            string[,] patron = new string[5, 5];
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (f == 4)
                    {
                        if (c == 1 || c == 2 || c == 3)
                            patron[f, c] = "X";
                    }
                    else
                    {
                        if (c == 0 || c == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <resumen>
        /// Metodo para jugar Letra P
        /// </resumen>
        /// <returns>Carton listo para jugar</returns>
        public string[,] patronP()
        {
            string[,] patron = new string[5, 5];
            for (int c = 0; c < 3; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0)
                        patron[f, c] = "X";
                    if (c == 1)
                    {
                        if (f == 0 || f == 2)
                            patron[f, c] = "X";
                    }
                    if (c == 2)
                    {
                        if (f == 0 || f == 1 || f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <resumen>
        /// Metodo para jugar Letra A
        /// </resumen>
        /// <returns>Carton listo para jugar</returns>
        public string[,] patronA()
        {
            string[,] patron = new string[5, 5];
            patron[0, 2] = "X";
            for (int c = 0; c < 5; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0 || c == 4)
                    {
                        patron[f, c] = "X";
                    }
                    else
                    {
                        if (f == 0 || f == 2)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        /// <resumen>
        /// Metodo para jugar Letra E
        /// </resumen>
        /// <returns>Carton Listo para jugar</returns>
        public string[,] patronE()
        {
            string[,] patron = new string[5, 5];
            patron[0, 2] = "X";
            for (int c = 0; c < 5; c++)
            {
                for (int f = 0; f < 5; f++)
                {
                    if (c == 0)
                    {
                        patron[f, c] = "X";
                    }
                    else
                    {
                        if (f == 0 || f == 2 || f == 4)
                            patron[f, c] = "X";
                    }
                }
            }
            patron[2, 2] = "XXXXXX";
            return patron;
        }

        #endregion
    }
}
