using Havan.Ecommerce.Padronizacao.Back.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Havan.Ecommerce.Padronizacao.Back.Api
{
    public class ControladorBase : ControllerBase
    {
        protected new IActionResult Response<T>(ResultadoOperacao<T> resultado)
            => StatusCode(resultado.StatusCode, resultado);

        protected new IActionResult Response(IResultadoOperacao result)
        {
            return StatusCode(result.StatusCode, result);
        }
    }
}

