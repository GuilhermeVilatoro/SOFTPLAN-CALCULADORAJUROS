using CalculadoraJuros.Application.Services;
using CalculadoraJuros.Application.Services.Interfaces;
using CalculadoraJuros.Domain.Business;
using CalculadoraJuros.Domain.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraJuros.Infra.CrossCutting.IOC
{
    public static class InjectionDependencies
    {
        /// <summary>
        /// Responsável por realizar o registro das dependências.
        /// </summary>
        /// <param name="dependencies">Lista a qual será adicionada as dependências</param>
        public static void RegisterDependencies(IServiceCollection dependencies)
        {
            #region Business 
            dependencies.AddScoped<ICalculoJuros, CalculoJuros>();
            #endregion region

            #region Services 
            dependencies.AddScoped<ICalculoJurosService, CalculoJurosService>();
            #endregion region            
        }
    }
}