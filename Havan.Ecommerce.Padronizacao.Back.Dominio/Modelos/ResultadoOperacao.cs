using System.Collections.Generic;
using System.Net;

namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public class ResultadoOperacao : IResultadoOperacao
    {
        public int StatusCode { get; set; }
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }

        public ResultadoOperacao(HttpStatusCode statusCode = HttpStatusCode.BadRequest, bool sucesso = false)
        {
            StatusCode = (int)statusCode;
            Sucesso = sucesso;
            Erros = new();
        }

        public ResultadoOperacao(string erro, HttpStatusCode statusCode = HttpStatusCode.BadRequest, bool sucesso = false)
        {
            StatusCode = (int)statusCode;
            Sucesso = sucesso;
            Erros = new() { erro };
        }

        public ResultadoOperacao AdicionarRetorno(HttpStatusCode statusCode = HttpStatusCode.OK, bool sucesso = true)
        {
            Sucesso = sucesso;
            StatusCode = (int)statusCode;
            return this;
        }

        public ResultadoOperacao AdicionarErro(string mensagemErro, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Erros.Add(mensagemErro);
            StatusCode = (int)statusCode;
            Sucesso = false;
            return this;
        }
    }

    public class ResultadoOperacao<T> : IResultadoOperacao
    {
        public T Resultado { get; set; }
        public bool Sucesso { get; set; }
        public int StatusCode { get; set; }

        public ResultadoOperacao()
        {
            Sucesso = true;
            StatusCode = (int)HttpStatusCode.OK;
        }

        public ResultadoOperacao(T resultado)
        {
            Sucesso = true;
            StatusCode = (int)HttpStatusCode.OK;
            Resultado = resultado;
        }

        public ResultadoOperacao<T> AdicionarRetorno(T resultado)
        {
            Resultado = resultado;
            return this;
        }

        public ResultadoOperacao AdicionarErro(string mensagemErro, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new()
            {
                Erros = new() { mensagemErro },
                StatusCode = (int)statusCode,
                Sucesso = false
            };
        }

    }
}
