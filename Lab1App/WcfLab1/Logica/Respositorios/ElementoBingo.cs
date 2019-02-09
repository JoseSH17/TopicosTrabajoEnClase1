namespace WcfLab1.Domain.Respositories
{
    public class BingoRepo
    {
        // Declaracion de variables
        public string NumeroBolita { get; set; }
        public bool Estado { get; set; }

        // Constructor
        public BingoRepo(string _Numero, bool _Estado)
        {
            this.NumeroBolita = _Numero;
            this.Estado = _Estado;
        }
    }
}
