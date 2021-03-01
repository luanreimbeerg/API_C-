using System;

namespace API_C_.Models.Request
{
    public class DiretorRequest
    {
        public int idDiretor { get; set; }
        public string NmDiretor { get; set; }
        public DateTime DtNascimento { get; set; }
        public string NmFilme { get; set; }
    }
}