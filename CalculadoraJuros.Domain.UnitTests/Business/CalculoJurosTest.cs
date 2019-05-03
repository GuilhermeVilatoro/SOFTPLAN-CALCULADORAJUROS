using CalculadoraJuros.Domain.Business;
using CalculadoraJuros.Domain.Business.Dto;
using NSubstitute;
using NUnit.Framework;
using System;

namespace CalculadoraJuros.Domain.UnitTests.Business
{
    public class CalculoJurosTest
    {
        private InformacoesCalculoJuros informacoesCalculoJurosMock;

        private CalculoJuros calculoJurosBusiness;

        [SetUp]
        public void SetUp()
        {
            informacoesCalculoJurosMock = Substitute.For<InformacoesCalculoJuros>();
            calculoJurosBusiness = new CalculoJuros();
        }

        [Test]
        public void Teste()
        {
            informacoesCalculoJurosMock.ValorInicial = 100;
            informacoesCalculoJurosMock.TempoEmMeses = 5;
            var t = calculoJurosBusiness.Calcular(informacoesCalculoJurosMock);

            var t1 = t.ToString("N2");
            var t2 = Convert.ToDecimal(t1);
        }
    }
}