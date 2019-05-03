using CalculadoraJuros.Domain.Exceptions;

namespace CalculadoraJuros.Domain.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Responsável por calcular a potência com precisão de um decimal.
        /// </summary>       
        /// <param name="baseExpoente">A decimal-precision floating-point number to be raised to a power</param>
        /// <param name="expoente">A double-precision floating-point number that specifies a power</param>
        /// <returns>Retorna a potência com uma maior precisão</returns>
        public static decimal MathPow(this decimal baseExpoente, int expoente)
        {
            if (expoente < 0)
                throw new BusinessException("O expoente não pode ser negativo!");

            if (expoente == 0)
                return 1M;

            decimal potencia = 1M;
            for (int contador = 1; contador <= expoente; contador++)
                potencia *= baseExpoente;

            return potencia;
        }
    }
}