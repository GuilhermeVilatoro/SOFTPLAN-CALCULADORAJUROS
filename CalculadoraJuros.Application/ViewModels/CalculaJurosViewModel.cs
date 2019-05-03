using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraJuros.Application.ViewModels
{
    public class CalculaJurosViewModel
    {
        [Required(ErrorMessage = "Preencha o valor inicial")]        
        [DisplayName("Valor inicial sem juros")]
        public decimal ValorInicial { get; set; }

        [Required(ErrorMessage = "Preencha o tempo e meses")]
        [Range(typeof(int), "0", "1000")]
        [DisplayName("Tempo em meses")]
        public int TempoEmMeses { get; set; }      
    }
}