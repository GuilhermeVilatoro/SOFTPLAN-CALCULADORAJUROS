using CalculadoraJuros.Domain.Exceptions;
using CalculadoraJuros.Domain.Extensions;
using NUnit.Framework;

namespace CalculadoraJuros.Domain.UnitTests.Extensions
{
    public class DecimalExtensionsTest
    {
        private decimal taxaJuros;
        private decimal potencia;
        private decimal potenciaEsperada;
        private int expoente;

        [SetUp]
        public void SetUp()
        {
            taxaJuros = 1.01M;
            potenciaEsperada = 1M;
            expoente = -1;
        }

        [Test]
        public void Ao_Calcular_Potencia_Com_Expoente_Negativo_Deve_Retornar_Exception()
        {
            Assert.Throws<BusinessException>(() => taxaJuros.MathPow(expoente),
                "Não é possível determinar a potência com expoente negativo!");
        }

        [Test]
        public void Ao_Calcular_Potencia_Com_Expoente_Zerado_Deve_Retornar_O_Valor_Um()
        {
            expoente = 0;
            potencia = taxaJuros.MathPow(expoente);            
            Assert.AreEqual(potencia, potenciaEsperada, $"Qualquer base elevada a um expoente zerado deve retornar '{potenciaEsperada}'!");          
        }

        [Test]
        public void Ao_Calcular_Potencia_Com_Expoente_Maior_Que_Zero_Deve_Retornar_O_Valor_Calculado()
        {
            expoente = 5;
            potencia = taxaJuros.MathPow(expoente);
            potenciaEsperada = 1.0510100501M;
            Assert.AreEqual(potencia, potenciaEsperada, $"A potência deve ser '{potenciaEsperada}'!");
        }
    }
}