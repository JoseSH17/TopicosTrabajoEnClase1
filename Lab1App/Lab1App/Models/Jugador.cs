using System.Collections.Generic;
using WcfLab1.Domain.Respositories;

namespace Lab1App.Models
{
    public class Jugador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public BingoRepo[,] CartonDelJugador { get; set; }
        public List<int> NumerosMarcados { get; set; }

        public Jugador(string nombre, BingoRepo[,] cartonJugador, List<int> numerosMarcados)
        {
            Nombre = nombre;
            CartonDelJugador = cartonJugador;
            NumerosMarcados = numerosMarcados;
        }

        public Jugador()
        {
            this.NumerosMarcados = new List<int>();
            this.CartonDelJugador = new BingoRepo[5, 5];
        }
    }
}
