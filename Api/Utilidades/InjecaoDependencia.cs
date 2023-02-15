using Havan.Ecommerce.Padronizacao.Back.Aplicacao;
using Microsoft.Extensions.DependencyInjection;

namespace Havan.Ecommerce.Padronizacao.Back.Api
{
    public static class InjecaoDependencia
    {
        public static void Injetar(IServiceCollection servicos)
        {
            ConfigurarServico(servicos);
            ConfigurarAplicacao(servicos);
            ConfigurarRepositorio(servicos);
        }

        private static void ConfigurarServico(IServiceCollection servicos)
        {
            //servicos.AddTransient<interface, servico>();
            //servicos.AddTransient<interface, servico>();
        }

        private static void ConfigurarAplicacao(IServiceCollection servicos)
        {
            servicos.AddScoped<PizzaAplicacao>();
            //servicos.AddScoped<interface, servico>();
            //servicos.AddScoped<interface, servico>();
        }

        private static void ConfigurarRepositorio(IServiceCollection servicos)
        {
            //servicos.AddScoped<interface, servico>();
            //servicos.AddScoped<interface, servico>();
        }
    }
}
