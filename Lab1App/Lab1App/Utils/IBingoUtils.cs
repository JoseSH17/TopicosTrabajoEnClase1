using Lab1App.Models;
using System.Collections.Generic;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Utils
{
    public interface IBingoUtils
    {
        List<Jugador> CrearJugador(string[] nombres);
        BingoRepo[,] InicializarCarton(BingoRepo[,] m);
        BingoRepo[,] LlenarColumnas(char ColumnaActual, BingoRepo[,] m);
        int CalcularNumero(int PrimerNumero, int UltimoNumero);
    }
}
