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
        /// </summary>
        [HttpGet("Filtrar")]
        public IActionResult Get([FromQuery] FiltroDeBuscaPizzasModelo filtro)
            => Response(_pizzaAplicacao.Filtrar(filtro));
        
        /// <summary>
        /// Busca um sabor de pizza aleatorio.
        /// </summary>
        [HttpGet("ObterAleatoria")]
        public IActionResult ObterPizza()
            => Response(_pizzaAplicacao.Obter());

        /// <summary>
        /// Busca uma pizza por ID
        /// </summary>
        [HttpGet("ObterPorId")]
        public IActionResult ObterPizzaPorId(int id)
            => Response(_pizzaAplicacao.ObterPorId(id));

        /// <summary>
        /// Retorna um erro de servidor
        /// </summary>
        [HttpGet("ObterComErro")]
        public IActionResult ObterPizzaErrada()
            => Response(PizzaAplicacao.ObterComErro());

        /// <summary>
        /// Retorna um erro de servidor
        /// </summary>
        [HttpGet("ObterComVariosErros")]
        public IActionResult ObterPizzaComVariosErros()
            => Response(PizzaAplicacao.ObterComVariosErros());

        /// <summary>
        /// Busca um sabor de pizza aleatorio.
        /// </summary>
        [HttpPost("Adicionar")]
        public IActionResult AdicionarSabor(PizzaPost pizza)
            => Response(_pizzaAplicacao.AdicionarSabor(pizza));
    }
}
