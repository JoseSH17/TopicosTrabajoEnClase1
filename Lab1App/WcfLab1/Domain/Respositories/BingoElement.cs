using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLab1.Domain.Respositories
{
    public class BingoElement
    {
        public string Number { get; set; }
        public bool State { get; set; }

        public BingoElement(string _Number, bool _State)
        {
            this.Number = _Number;
            this.State = _State;
        }
    }
}