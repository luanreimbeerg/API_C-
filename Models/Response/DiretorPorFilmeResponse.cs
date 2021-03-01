using System;

namespace API_C_.Models.Response
{
    public class DiretorPorFilmeResponse
    {
        public int idDiretor { get; set; }
        public string NmDiretor { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string NmFilme { get; set; }
    }
}