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

        public IResultadoOperacao BuscarPizzas(FiltroDeBuscaPizzasModelo filtro)
        {
            ResultadoOperacao<List<Pizza>> resultado = new();
            try
            {
                return resultado.AdicionarRetorno(pizzas.FindAll(p => filtro.Ids.Contains(p.Id)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return resultado.AdicionarErro("Erro ao realizar a busca.");
            }
        }
        
        public IResultadoOperacao ObterPizza()
            => new ResultadoOperacao<Pizza>(pizzas[aleatorio.Next(pizzas.Count)]);

        public static IResultadoOperacao ObterPizzaErrada()
            => new ResultadoOperacao("Desculpe, no momento não conseguimos fazer sua pizza.");
    }
}
