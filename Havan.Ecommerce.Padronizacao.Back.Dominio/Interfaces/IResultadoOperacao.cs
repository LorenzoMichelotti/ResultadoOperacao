using System.Net;

namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public interface IResultadoOperacao
    {
        public bool Sucesso { get; set; }
        public int StatusCode { get; set; }
        ResultadoOperacao AdicionarErro(string mensagemErro, HttpStatusCode statusCode = HttpStatusCode.BadRequest);
    }

}
