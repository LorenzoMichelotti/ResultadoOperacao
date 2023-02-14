namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public class Pizza : IComida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string Descrição()
            => $"{Nome}, {Descricao}";

        public Pizza(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }

    public class PizzaPost
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string Descrição()
            => $"{Nome}, {Descricao}";

        public PizzaPost(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
