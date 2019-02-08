using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1UnitTest
{
    [TestClass]
    public class BingoActionsTest
    {

        [TestMethod]
        public void GetBingoColumnLetterTest()
        {
            WcfLab1.Domain.Actions.Bingo BingoAction = new WcfLab1.Domain.Actions.Bingo();
            var Result = BingoAction.GetBingoColumnLetter(5);
            Assert.IsTrue(Result.Equals("B"), "FalloB");

            Result = BingoAction.GetBingoColumnLetter(20);
            Assert.IsTrue(Result.Equals("I"), "Fallo I");

            Result = BingoAction.GetBingoColumnLetter(35);
            Assert.IsTrue(Result.Equals("I"), "Fallo N");

            Result = BingoAction.GetBingoColumnLetter(52);
            Assert.IsTrue(Result.Equals("I"), "Fallo G");

            Result = BingoAction.GetBingoColumnLetter(70);
            Assert.IsTrue(Result.Equals("I"), "Fallo O");
        }

        [TestMethod]
        public void CalculateNumber() {
            WcfLab1.Domain.Actions.Bingo BingoAction = new WcfLab1.Domain.Actions.Bingo();
            int num = BingoAction.CalculateNumber(1, 15);
            Assert.IsTrue(num >= 1 && num <= 15, "Fallo, el numero no se encuentra en el rango esperado (1 a 15)");

            num = BingoAction.CalculateNumber(16, 30);
            Assert.IsTrue(num >= 16 && num <= 30, "Fallo, el numero no se encuentra en el rango esperado (16 a 30)");

            num = BingoAction.CalculateNumber(31, 45);
            Assert.IsTrue(num >= 31 && num <= 45, "Fallo, el numero no se encuentra en el rango esperado (31 a 45)");

            num = BingoAction.CalculateNumber(46, 60);
            Assert.IsTrue(num >= 46 && num <= 60, "Fallo, el numero no se encuentra en el rango esperado (46 a 60)");

            num = BingoAction.CalculateNumber(61, 75);
            Assert.IsTrue(num >= 61 && num <= 75, "Fallo, el numero no se encuentra en el rango esperado (61 a 75)");
        }


        [TestMethod]
        public void GetWinnerPatternFull() {
            WcfLab1.Domain.Actions.Bingo BingoAction = new WcfLab1.Domain.Actions.Bingo();
            string[,] WinnerPatter = BingoAction.GetWinnerPattern(WcfLab1.Domain.Services.GameType.Full);
            string[,] patter = BingoAction.patternFull();
            int wp =0; int p = 0;
            for (int f =0; f<5;f++) {
                for (int c = 0; c < 5; c++) {
                    if (WinnerPatter[f, c].Equals("X"))
                        wp++;
                    if (patter[f, c].Equals("X"))
                        p++;
                }
            }
            Assert.IsTrue(wp == p, "Fallo en la selección del patron");
        }



    }
}
