using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLab1.Domain.Services;
using WcfLab1.Domain.Respositories;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Lab1App.Application;
using Lab1App.Utils;
using Lab1App.Presentation;
using Lab1App.GUI;

namespace Lab1App
{
    class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<BingoApplication>());
            container.Register(Component.For<IBingoGUI>()
                .ImplementedBy<BingoGUI>());
            container.Register(Component.For<IBingo>()
                .ImplementedBy<Bingo>().LifestyleSingleton());
            container.Register(Component.For<IBingoUtils>()
                .ImplementedBy<BingoUtils>().LifestyleSingleton());

            var bingoApplication = container.Resolve<BingoApplication>();
            bingoApplication.PlayBingo();
        }
    }
}
