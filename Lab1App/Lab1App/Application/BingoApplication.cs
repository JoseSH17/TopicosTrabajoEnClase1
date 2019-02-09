using Lab1App.GUI;
using Lab1App.Models;
using Lab1App.Utils;
using System.Collections.Generic;
using WcfLab1.Domain.Services;

namespace Lab1App.Application
{
    public class BingoApplication
    {
        private readonly IBingoUtils utils;
        private readonly IBingoGUI bingoGUI;
        private readonly IBingo WFCBingo;

        public BingoApplication(IBingoUtils _utils, IBingoGUI _bingoGUI, IBingo _WFCBingo)
        {
            this.utils = _utils;
            this.bingoGUI = _bingoGUI;
            this.WFCBingo = _WFCBingo;
        }

        /// <resumen>
        /// Metodo que pregunta por el numero de jugadores, sus datos y el modo de juego 
        /// </>
        /// <returns>cartones respectivos</returns>
        public Juego PrepararJuego()
        {
            bingoGUI.MensajesDeBienvenida();
            string[] nombreJugadores = bingoGUI.ObtenerNombresDeJugadores();
            List<Jugador> listaJugadores = utils.CrearJugador(nombreJugadores);
            bingoGUI.ImprimirJugadoresYCartones(listaJugadores);
            return new Juego(bingoGUI.SeleccionarModoDeJuego(), listaJugadores);
        }

        public string PrepararTareaPrincipal(Juego juego)
        {
            List<int> listaNumeros = new List<int>();
            int NumeroActual = 0;
            bool ResultadoBingo = false;
            while (!ResultadoBingo)
            {
                bingoGUI.MensajeSacarBolita();
                NumeroActual = WFCBingo.ObtenerNumero(listaNumeros);
                listaNumeros.Add(NumeroActual);
                bingoGUI.MostrarListaNumerosFavorecidos(listaNumeros);
                foreach (var jg in juego.ListaJugadores)
                {
                    if (WFCBingo.ObtenerGanador(juego.ModoJuego, jg.CartonDelJugador))
                    {
                        bingoGUI.ImprimirJugadoresYCartones(juego.ListaJugadores);
                        return jg.Nombre;
                    }
                }
                bingoGUI.MarcarNumeros(NumeroActual, juego.ListaJugadores);
                bingoGUI.ImprimirJugadoresYCartones(juego.ListaJugadores);
            }
            return null;
        }

        /// <resumen>
        /// Ejecuta la accion principal del juego
        /// </resumen>
        public void JugarBingo()
        {
            var juego = PrepararJuego();
            bingoGUI.MensajeDeInicioDeJuego();
            bingoGUI.MostrarGanador(PrepararTareaPrincipal(juego));
            bingoGUI.MensajeDespedida();
        }

    }
}
