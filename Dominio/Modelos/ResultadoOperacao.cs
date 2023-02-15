using System.Collections.Generic;
using System.Net;

namespace Havan.Ecommerce.Padronizacao.Back.Dominio
{
    public class ResultadoOperacaoErro
    {
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public string Propriedade { get; set; }

        public ResultadoOperacaoErro(string tipo, string mensagem = "", string propriedade = "")
        {
            Tipo = tipo;
            Mensagem = mensagem;
            Propriedade = propriedade;
        }
    }

    public class ResultadoOperacao : IResultadoOperacao
    {
        public int CodigoStatus { get; set; }
        public string Tipo { get; set; }
        public bool Sucesso { get; set; }
        public List<ResultadoOperacaoErro> Erros { get; set; }

        public ResultadoOperacao(HttpStatusCode statusCode = HttpStatusCode.BadRequest, bool sucesso = false)
        {
            CodigoStatus = (int)statusCode;
            Sucesso = sucesso;
            Erros = new();
        }

        public ResultadoOperacao(ResultadoOperacaoErro erro, HttpStatusCode statusCode = HttpStatusCode.BadRequest, bool sucesso = false)
        {
            CodigoStatus = (int)statusCode;
            Sucesso = sucesso;
            Erros = new() { erro };
        }

        public ResultadoOperacao AdicionarRetorno(HttpStatusCode statusCode = HttpStatusCode.OK, bool sucesso = true)
        {
            Sucesso = sucesso;
            CodigoStatus = (int)statusCode;
            return this;
        }

        public ResultadoOperacao AdicionarErro(ResultadoOperacaoErro erro, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Erros.Add(erro);
            CodigoStatus = (int)statusCode;
            Sucesso = false;
            return this;
        }
    }

    public class ResultadoOperacao<T> : IResultadoOperacao
    {
        public T Resultado { get; set; }
        public bool Sucesso { get; set; }
        public int CodigoStatus { get; set; }
        public string Tipo { get; set; }

        public ResultadoOperacao()
        {
            Sucesso = true;
            CodigoStatus = (int)HttpStatusCode.OK;
        }

        public ResultadoOperacao(T resultado)
        {
            Sucesso = true;
            CodigoStatus = (int)HttpStatusCode.OK;
            Resultado = resultado;
        }

        public ResultadoOperacao<T> AdicionarRetorno(T resultado, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Resultado = resultado;
            CodigoStatus = (int)statusCode;
            return this;
        }

        public ResultadoOperacao AdicionarErro(ResultadoOperacaoErro erro, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new()
            {
                Erros = new() { erro },
                CodigoStatus = (int)statusCode,
                Sucesso = false
            };
        }

    }
}
