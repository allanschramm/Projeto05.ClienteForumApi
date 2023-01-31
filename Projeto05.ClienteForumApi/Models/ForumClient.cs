namespace Projeto05.ClienteForumApi.Models
{
    public class ForumClient
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public string? Responsavel { get; set; }
        public string? Telefone { get; set; }
    }
}
