using System;
using System.Collections.Generic;
using WcfLab1.Domain.Services;
using WcfLab1.Domain.Respositories;
using Lab1App.GUI;
using Lab1App.Models;

namespace Lab1App.Presentation
{
    public class BingoGUI : IBingoGUI
    {
    
    // Metodo despliegue menu para los jugadores
        #region MostrarMensajes
        public void MensajesDeBienvenida()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("        Bienvenidos es hora de jugar Bingo!!!");
            Console.WriteLine("======================================================");
            Console.WriteLine("            Presione ENTER para continuar");
            Console.ReadKey();
            Console.Clear();
        }
   
      // Recibe la orden cuando el usuario este listo para jugar
        public void MensajeDeInicioDeJuego()
        {
            Console.WriteLine("");
            Console.WriteLine("Hora de jugar!!! (Presione ENTER para iniciar el juego)");
            Console.ReadKey();
        }

      // lee los numeros aleatorios para empezar a llenar el carton
        public void MensajeSacarBolita()
        {
            Console.WriteLine("\nPresione ENTER para sacar otra bolita");
            Console.ReadKey();
            Console.Clear();
        }

      // Metodo para aviso de juego terminado
        public void MensajeDespedida()
        {
            Console.WriteLine("\nEl juego ha terminado");
            Console.ReadKey();
        }

        #endregion

        #region Preparacion del juego
        //  Obtiene los datos de los jugadores y verifica que esten la cantidad necesaria
        public string[] ObtenerNombresDeJugadores()
        {
            int cantJugadores = 0;
            while (true)
            {
                Console.WriteLine("Por favor digite la cantidad de jugadores participantes");
                if (int.TryParse(Console.ReadLine(), out cantJugadores))
                {
                    if (cantJugadores > 0 && cantJugadores <= 10)
                    {
                        string[] nombres = new string[cantJugadores];
                        for (int i = 0; i < cantJugadores; i++)
                        {
                            Console.WriteLine("Nombre del jugador #{0}:", i + 1);
                            nombres[i] = Console.ReadLine();
                        }
                        Console.Clear();
                        return nombres;
                    }
                    Console.WriteLine("Lo sentimos, solo pueden jugar de 1 a 10 personas");
                }
                Console.WriteLine("Dato invalido (Presione enter para continuar)");
                Console.ReadKey();
                Console.Clear();
            }
        }
     // Metodo de despliegue de menu al usuario sobre modo de juego de Bingo
        public ModoDeJuego SeleccionarModoDeJuego()
        {
            while (true)
            {
                Console.WriteLine("Seleccione el modo de juego");
                Console.WriteLine("1) Carton lleno");
                Console.WriteLine("2) 4 Esquinas");
                Console.WriteLine("3) Formar H");
                Console.WriteLine("4) Formar X");
                Console.WriteLine("5) Formar O");
                //Console.WriteLine("6) Formar U");
                //Console.WriteLine("7) Formar P");
                //Console.WriteLine("8) Formar A");
                //Console.WriteLine("9) Formar E");
                int Resp = int.Parse(Console.ReadLine());

                switch (Resp)
                {
                    case 1:
                        return ModoDeJuego.CartonLleno;
                    case 2:
                        return ModoDeJuego.CuatroEsquinas;
                    case 3:
                        return ModoDeJuego.H;
                    case 4:
                        return ModoDeJuego.X;
                    case 5:
                        return ModoDeJuego.O;
                    //case 6:
                    //    return ModoDeJuego.U;
                    //case 7:
                    //    return ModoDeJuego.P;
                    //case 8:
                    //    return ModoDeJuego.A;
                    //case 9:
                    //    return ModoDeJuego.E;
                    default:
                        Console.WriteLine("La opcion ingresada no es valida, por favor seleccione un numero que corresponda a la lista");
                        break;
                }
            }
        }

        /// <summary>
        // Imprime los cartones a los usuarios correspondientes y los muestra en pantalla
        /// </summary>
        /// <param name="jugador"></param>
        public void ImprimirCarton(Jugador jugador)
        {
            BingoRepo Elemento;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Elemento = jugador.CartonDelJugador[i, j];
                    if (Elemento.Estado)
                    {
                        string NuevaBolita = Elemento.NumeroBolita.Substring(1, 2);

                        Console.Write(" {0} [X]", NuevaBolita);
                    }
                    else
                    {
                        string NumeroModificado = Elemento.NumeroBolita;
                        if (!NumeroModificado.Equals(" XXXXXX"))
                        {
                            if (NumeroModificado.Substring(1, 2).Contains(" "))
                            {
                                NumeroModificado = " 0" + NumeroModificado.Substring(1, 2) + "[ ]";
                            }
                        }
                        Console.Write(NumeroModificado);
                    }
                }
                Console.WriteLine("");
            }
        }

        #endregion

        #region Ejecutar Tareas Principales

   // Muestra, el ganador del juego
        public void MostrarGanador(string NombreJugador)
        {
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("        Felicidades {0} es el ganador!!!", NombreJugador);
            Console.WriteLine("======================================================");
        }

       
        public void ImprimirJugadoresYCartones(List<Jugador> ListaJugadores)
        {
            foreach (var jugador in ListaJugadores)
            {
                Console.WriteLine("\nCarton de {0}:", jugador.Nombre);
                ImprimirCarton(jugador);
                if (jugador.NumerosMarcados.Count != 0)
                {
                    ImprimirNumerosMarcados(jugador);
                }
            }
            Console.WriteLine("\n\n");
        }

        /// <resumen>
        // Metodo que muestra en pantalla los numeros marcados en cada carton
        /// </resumen>
        /// <parametro1="jugador"></param>
        public void ImprimirNumerosMarcados(Jugador jugador)
        {
            Console.WriteLine("\n{0}'s Lista de numeros marcados: {1}", jugador.Nombre, string.Join(",", jugador.NumerosMarcados));
            Console.WriteLine("------------------------------------------------------------------");
        }

        /// <resumen>
         // Metodo que realiza seguimiento de los numeros que salieron y que cartones contiene dichos numeros
        /// </summary>
        /// <parametro1="NumeroActual"></param>
        /// <parametro2="ListaJugadores"></param>
        public void MarcarNumeros(int NumeroActual, List<Jugador> ListaJugadores)
        {
            foreach (var jg in ListaJugadores)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!(jg.CartonDelJugador[i, j].NumeroBolita.Equals(" XXXXXX")))
                        {
                            if (Convert.ToInt32(jg.CartonDelJugador[i, j].NumeroBolita.Substring(1, 2)) == NumeroActual)
                            {
                                jg.CartonDelJugador[i, j].Estado = true;
                                Console.WriteLine("Numeros de {0} {1}:[{2}][{3}]", jg.Nombre, NumeroActual, i + 1, j + 1);
                                jg.NumerosMarcados.Add(NumeroActual);
                            }
                        }
                    }
                }
            }
        }
            // Metodo que muestra la lista de los numeros que salieron en el juego
        public void MostrarListaNumerosFavorecidos(List<int> ListaNumeros)
        {
            Console.WriteLine("Lista de numeros {0} jugados:", ListaNumeros.Count);
            Console.WriteLine("{0}", string.Join(",", ListaNumeros));
        }

        #endregion
    }
}
