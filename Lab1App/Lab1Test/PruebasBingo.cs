using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1UnitTest
{
    [TestClass]
    public class PruebasDeBingo
    {
       // Prueba asignar cada letra de la palabra bingo 
        [TestMethod]
        public void PruebaObtenerLetraDeColumnaBingo()
        {
            WcfLab1.Domain.Actions.Bingo Accion = new WcfLab1.Domain.Actions.Bingo();
            var Result = Accion.ObtenerLetraDeColumnaBingo(5);
            Assert.IsTrue(Result.Equals("B"), "Error B");

            Result = Accion.ObtenerLetraDeColumnaBingo(20);
            Assert.IsTrue(Result.Equals("I"), "Error I");

            Result = Accion.ObtenerLetraDeColumnaBingo(35);
            Assert.IsTrue(Result.Equals("I"), "Error N");

            Result = Accion.ObtenerLetraDeColumnaBingo(52);
            Assert.IsTrue(Result.Equals("I"), "Error G");

            Result = Accion.ObtenerLetraDeColumnaBingo(70);
            Assert.IsTrue(Result.Equals("I"), "Error O");
        }
        
 // Prueba calculo de numeros en un rango especifico 
        [TestMethod]
        public void PruebaCalculoDeNumero() {
            WcfLab1.Domain.Actions.Bingo Accion = new WcfLab1.Domain.Actions.Bingo();
            int num = Accion.CalcularNumero(1, 15);
            Assert.IsTrue(num >= 1 && num <= 15, "Error, el numero no se encuentra en el rango esperado (1 a 15)");

            num = Accion.CalcularNumero(16, 30);
            Assert.IsTrue(num >= 16 && num <= 30, "Error, el numero no se encuentra en el rango esperado (16 a 30)");

            num = Accion.CalcularNumero(31, 45);
            Assert.IsTrue(num >= 31 && num <= 45, "Error, el numero no se encuentra en el rango esperado (31 a 45)");

            num = Accion.CalcularNumero(46, 60);
            Assert.IsTrue(num >= 46 && num <= 60, "Error, el numero no se encuentra en el rango esperado (46 a 60)");

            num = Accion.CalcularNumero(61, 75);
            Assert.IsTrue(num >= 61 && num <= 75, "Error, el numero no se encuentra en el rango esperado (61 a 75)");
        }

            //  Prueba obtener ganador
        [TestMethod]
        public void PruebaObtenerPatronGanador() {
            WcfLab1.Domain.Actions.Bingo Accion = new WcfLab1.Domain.Actions.Bingo();
            string[,] PatronGanador = Accion.ObtenerPatronGanador(WcfLab1.Domain.Services.ModoDeJuego.CartonLleno);
            string[,] patron = Accion.LLenarPatron();
            int wp =0; int p = 0;
            for (int f =0; f<5;f++) {
                for (int c = 0; c < 5; c++) {
                    if (PatronGanador[f, c].Equals("X"))
                        wp++;
                    if (patron[f, c].Equals("X"))
                        p++;
                }
            }
            Assert.IsTrue(wp == p, "Error en la selección del patron");
        }

    }
}
