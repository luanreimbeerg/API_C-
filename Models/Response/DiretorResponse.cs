namespace API_C_.Models.Response
{
    public class DiretorResponse
    {
        public int idDiretor { get; set; }

        public int? idFilme { get; set; }

        public string Diretor { get; set; }

        public string Filme { get; set; }

        public string Genero { get; set; }

        public bool? Disponivel { get; set; }
    }
}