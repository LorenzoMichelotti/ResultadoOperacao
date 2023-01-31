using Havan.Ecommerce.Padronizacao.Back.Aplicacao;
using Havan.Ecommerce.Padronizacao.Back.Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Havan.Ecommerce.Padronizacao.Back.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControladorBase
    {
        private readonly PizzaAplicacao _pizzaAplicacao;
        public PizzaController(PizzaAplicacao pizzaAplicacao)
        {
            _pizzaAplicacao = pizzaAplicacao;
        }

        /// <summary>
        /// Busca pizzas por uma lista de ids.
        /// GET: api/<PizzasController>
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarPizzas")]
        public IActionResult Get([FromQuery] FiltroDeBuscaPizzasModelo filtro)
            => Response(_pizzaAplicacao.BuscarPizzas(filtro));
        
        /// <summary>
        /// Busca um sabor de pizza aleatorio.
        /// GET: api/<PizzasController>
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterPizza")]
        public IActionResult Get()
            => Response(_pizzaAplicacao.ObterPizza());

        [HttpGet("ObterPizzaErrada")]
        public IActionResult ObterPizzaErrada()
            => Response(PizzaAplicacao.ObterPizzaErrada());
    }
}
