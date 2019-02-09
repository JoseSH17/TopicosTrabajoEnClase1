using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLab1.Domain.Respositories
{
    public class BingoElement
    {
        // Declaracion de variables
        public string Number { get; set; }
        public bool State { get; set; }

        // Constructor
        public BingoElement(string _Number, bool _State)
        {
            this.Number = _Number;
            this.State = _State;
        }
    }
}
