using Havan.Ecommerce.Padronizacao.Back.Dominio;
using System;
using System.Collections.Generic;

namespace Havan.Ecommerce.Padronizacao.Back.Aplicacao
{
    public class PizzaAplicacao
    {
        static readonly Random aleatorio = new Random();

        readonly List<Pizza> pizzas = new List<Pizza>() {
            new(1, "Pizza Pepperoni", "Queijo Mussarela, Pepperoni e Molho de tomate"),
            new(2, "Pizza Mussarela", "Queijo Mussarela e Molho de tomate"),
            new(3, "Pizza Portuguesa", "Presunto, Queijo, Ovo  Cozido e Molho de tomate")
        };

        public IResultadoOperacao Filtrar(FiltroDeBuscaPizzasModelo filtro)
        {
            ResultadoOperacao<List<Pizza>> resultado = new();
            try
            {
                return resultado.AdicionarRetorno(pizzas.FindAll(p => filtro.Ids.Contains(p.Id)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return resultado.AdicionarErro(new("E1004", MensagensDeErroRecurso.E1004_ErroNaBusca));
            }
        }
        
        public IResultadoOperacao Obter()
            => new ResultadoOperacao<Pizza>(pizzas[aleatorio.Next(pizzas.Count)]);

        public IResultadoOperacao ObterPorId(int id)
        {
            ResultadoOperacao<Pizza> resultado = new();
            Pizza pizza = pizzas.Find(p => p.Id == id);
            if (pizza == null) return resultado.AdicionarErro(
                new ("E1000",
                MensagensDeErroRecurso.E1000_NenhumaPizzaComIdentificador, "id"),
                System.Net.HttpStatusCode.NotFound);
            return resultado.AdicionarRetorno(pizza);
        }

        public static IResultadoOperacao ObterComErro()
            => new ResultadoOperacao(new("E1001", MensagensDeErroRecurso.E1001_ErroNoServidor), System.Net.HttpStatusCode.InternalServerError);

        public static IResultadoOperacao ObterComVariosErros()
        {
            ResultadoOperacao resultado = new ResultadoOperacao();
            resultado.AdicionarErro(new("E1002", MensagensDeErroRecurso.E1002_PizzaQueimou), System.Net.HttpStatusCode.NotAcceptable);
            resultado.AdicionarErro(new("E1003", MensagensDeErroRecurso.E1003_PizzaDesapareceu), System.Net.HttpStatusCode.Gone);
            return resultado;
        }

        public IResultadoOperacao AdicionarSabor(PizzaPost pizza)
        {
            ResultadoOperacao<Pizza> resultado = new();
            Pizza novoSabor = new Pizza(pizzas.Count, pizza.Nome, pizza.Descricao);
            pizzas.Add(novoSabor);
            return resultado.AdicionarRetorno(novoSabor, System.Net.HttpStatusCode.Created);
        }
    }
}
