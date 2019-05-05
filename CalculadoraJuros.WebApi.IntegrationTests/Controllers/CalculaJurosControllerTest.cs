using CalculadoraJuros.Application.Services.Interfaces;
using CalculadoraJuros.Application.ViewModels;
using CalculadoraJuros.Infra.CrossCutting.IOC;
using CalculadoraJuros.WebApi.Configurations;
using CalculadoraJuros.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using System;

namespace CalculadoraJuros.WebApi.IntegrationTests.Controllers
{
    public class CalculaJurosControllerTest
    {
        private CalculaJurosController _calculaJurosController;

        private CalculaJurosViewModel calculaJurosViewModelMock;
        private OkObjectResult resultadoOkMock;
        private ObjectResult resultadoErroMock;

        private const int STATUSCODESUCESSO = 200;

        private string calculoJuros;

        private IServiceCollection serviceCollection;

        [SetUp]
        public void SetUp()
        {
            serviceCollection = new ServiceCollection();

            AutoMapperSetup.AddAutoMapperSetup(serviceCollection);

            InjectionDependencies.RegisterDependencies(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var calculoJurosService = serviceProvider.GetService<ICalculoJurosService>();
            _calculaJurosController = new CalculaJurosController(calculoJurosService);

            calculaJurosViewModelMock = Substitute.For<CalculaJurosViewModel>();
            calculaJurosViewModelMock.ValorInicial = 100;
            calculaJurosViewModelMock.TempoEmMeses = 5;

            calculoJuros = "105,10";
            resultadoOkMock = _calculaJurosController.Ok(new { success = true, data = calculoJuros });

            resultadoErroMock = new ObjectResult($"Erro ao calcular juros: O tempo em meses não pode ser negativo!");
        }

        [Test]
        public void Ao_Realizar_Consumo_Calculo_Juros_Api_Sem_Informacoes_De_Calculo_Deve_Retornar_Erro()
        {
            Assert.Throws<ArgumentNullException>(
                () => _calculaJurosController.PostCalculaJurosViewModel(null),
                   "Não deve ser realizado o cálculo do juros sem as informações predefinidas!");
        }

        [Test]
        public void Ao_Realizar_Consumo_Calculo_Juros_Api_Com_Informacao_De_Calculo_Invalida_Deve_Retornar_Mensagem_Erro()
        {
            calculaJurosViewModelMock.TempoEmMeses = -5;

            var resultado = _calculaJurosController.PostCalculaJurosViewModel(calculaJurosViewModelMock);

            Assert.IsInstanceOf(typeof(ObjectResult), resultado);

            var errorResult = resultado as ObjectResult;

            Assert.AreEqual(resultadoErroMock.Value.ToString(), errorResult.Value.ToString(), $"Não deve ser calculado juros quando o tempo em meses for negativo!");
        }

        [Test]
        public void Ao_Realizar_Consumo_Calculo_Juros_Api_Deve_Retornar_Valor_Calculado_Com_Juros()
        {
            var resultado = _calculaJurosController.PostCalculaJurosViewModel(calculaJurosViewModelMock);

            Assert.IsInstanceOf(typeof(OkObjectResult), resultado);

            var okResult = resultado as OkObjectResult;

            Assert.IsTrue(okResult.StatusCode == STATUSCODESUCESSO, "O Serviço deve ser consumido com sucesso!");

            Assert.AreEqual(resultadoOkMock.Value.ToString(), okResult.Value.ToString(), $"O valor com juros deve ser R$ { calculoJuros }!");
        }

        [TearDown]
        public void TearDown()
        {
            AutoMapperSetup.RemoveAutoMapperSetup(serviceCollection);
        }
    }
}