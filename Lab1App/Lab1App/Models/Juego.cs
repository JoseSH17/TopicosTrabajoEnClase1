using System.Collections.Generic;
using WcfLab1.Domain.Services;

namespace Lab1App.Models
{
    public class Juego
    {
        public ModoDeJuego ModoJuego { get; set; }
        public List<Jugador> ListaJugadores { get; set; }

        public Juego (ModoDeJuego _ModoDeJuego, List<Jugador> ListaJugadores)
        {
            this.ModoJuego = _ModoDeJuego;
            this.ListaJugadores = ListaJugadores;
        }
    }
}
