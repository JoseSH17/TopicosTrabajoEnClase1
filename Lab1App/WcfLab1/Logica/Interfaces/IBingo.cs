using System.Collections.Generic;
using System.ServiceModel;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Services
{
    // Interface tipo de juego del bingo
    public enum ModoDeJuego
    {
        CartonLleno,CuatroEsquinas,H,X,O,U,P,A,E
    }
   // llama a los metodos obtenernumeros para empezar a asignar numeros aleatorios entre 1 y 75 y obtiene el ganador invocando al metodo obtener ganador
    [ServiceContract]
    public interface IBingo
    {
        [OperationContract]
        int ObtenerNumero(List<int> ListaNumeros);
        bool ObtenerGanador(ModoDeJuego TipoJuego, BingoRepo[,] Carton);
    }
}
