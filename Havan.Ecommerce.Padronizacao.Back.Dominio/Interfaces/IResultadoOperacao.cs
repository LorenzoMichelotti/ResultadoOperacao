using System.Net;

namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public interface IResultadoOperacao
    {
        public bool Sucesso { get; set; }
        public int CodigoStatus { get; set; }
        public string Tipo { get; set; }
        ResultadoOperacao AdicionarErro(ResultadoOperacaoErro erro, HttpStatusCode statusCode = HttpStatusCode.BadRequest);
    }

}
