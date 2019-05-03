using CalculadoraJuros.Domain.Business;
using CalculadoraJuros.Domain.Business.Dto;
using CalculadoraJuros.Domain.Exceptions;
using NSubstitute;
using NUnit.Framework;
using System;

namespace CalculadoraJuros.Domain.UnitTests.Business
{
    public class CalculoJurosTest
    {
        private InformacoesCalculoJuros informacoesCalculoJurosMock;

        private CalculoJuros calculoJurosBusiness;

        private decimal valorCalculado;
        private decimal valorCalculadoEsperado;

        [SetUp]
        public void SetUp()
        {
            informacoesCalculoJurosMock = Substitute.For<InformacoesCalculoJuros>();
            informacoesCalculoJurosMock.ValorInicial = 1350.577M;
            informacoesCalculoJurosMock.TempoEmMeses = -1;
            calculoJurosBusiness = new CalculoJuros();
        }

        [Test]
        public void Ao_Calcular_Juros_Sem_As_Informacoes_Juros_Multa_Nao_Deve_Calcular_Juros()
        {
            Assert.Throws<ArgumentNullException>(
                () => calculoJurosBusiness.Calcular(null),
                   "Não deve ser realizado o cálculo do juros sem as informações predefinidas!");
        }

        [Test]
        public void Ao_Calcular_Juros_Informando_Tempo_Negativo_Nao_Deve_Calcular_Juros()
        {
            Assert.Throws<BusinessException>(
               () => calculoJurosBusiness.Calcular(informacoesCalculoJurosMock),
                  "O cálculo de juros não deve ser realizado, quando o tempo em meses for negativo!");
        }

        [Test]
        public void Ao_Calcular_Juros_Informando_Tempo_Zerado_Deve_Calcular_Juros_Sem_Acrescimo_Com_Precisao_Duas_Casas_Decimais()
        {
            informacoesCalculoJurosMock.TempoEmMeses = 0;

            valorCalculado = calculoJurosBusiness.Calcular(informacoesCalculoJurosMock);
            valorCalculadoEsperado = 1350.57M;

            Assert.AreEqual(valorCalculado, valorCalculadoEsperado,
                "O valor calculado deve ser igual ao valor inicial com duas casas decimais, quando a quantidade de meses for zero!");
        }

        [Test]
        public void Ao_Calcular_Juros_Em_Cima_De_Um_Valor_Inicial_Zerado_O_Valor_Final_Deve_Ser_Zero()
        {
            informacoesCalculoJurosMock.ValorInicial = 0;
            informacoesCalculoJurosMock.TempoEmMeses = 5;

            valorCalculado = calculoJurosBusiness.Calcular(informacoesCalculoJurosMock);

            Assert.AreEqual(valorCalculado, informacoesCalculoJurosMock.ValorInicial,
                "O valor calculado deve ser zero, quando o valor inicial for zero!");
        }

        [Test]
        public void Ao_Calcular_Juros_Em_Cima_De_Um_Valor_Inicial_Negativo_O_Valor_Final_Deve_Ser_Calculado_E_Negativo()
        {
            informacoesCalculoJurosMock.ValorInicial = -100;
            informacoesCalculoJurosMock.TempoEmMeses = 5;

            valorCalculado = calculoJurosBusiness.Calcular(informacoesCalculoJurosMock);

            Assert.IsTrue(valorCalculado < 0, "O valor calculado deve negativo!");
        }

        [Test]
        public void Ao_Calcular_Juros_Em_Cima_De_Um_Valor_Inicial_Positivo_O_Valor_Final_Deve_Ser_Calculado()
        {
            informacoesCalculoJurosMock.TempoEmMeses = 5;
            informacoesCalculoJurosMock.ValorInicial = 100M;

            valorCalculado = calculoJurosBusiness.Calcular(informacoesCalculoJurosMock);

            valorCalculadoEsperado = 105.10M;

            Assert.AreEqual(valorCalculado, valorCalculadoEsperado, $"O valor calculado deve ser '{valorCalculadoEsperado}'!");
        }
    }
}