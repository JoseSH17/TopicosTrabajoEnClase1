using Lab1App.Models;
using System.Collections.Generic;
using WcfLab1.Domain.Services;

namespace Lab1App.GUI
{
    public interface IBingoGUI
    {
        string[] ObtenerNombresDeJugadores();
        ModoDeJuego SeleccionarModoDeJuego();
        void ImprimirJugadoresYCartones(List<Jugador> ListaJugadores);
        void ImprimirCarton(Jugador jugador);
        void MarcarNumeros(int CurrentNumber, List<Jugador> ListaJugadores);
        void ImprimirNumerosMarcados(Jugador player);
        void MostrarListaNumerosFavorecidos(List<int> ListaNumeros);
        void MostrarGanador(string NombreJugador);
        void MensajesDeBienvenida();
        void MensajeDespedida();
        void MensajeDeInicioDeJuego();
        void MensajeSacarBolita();
    }
}
