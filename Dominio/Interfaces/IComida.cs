namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public interface IComida : IBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string Descrição();
    }
}
