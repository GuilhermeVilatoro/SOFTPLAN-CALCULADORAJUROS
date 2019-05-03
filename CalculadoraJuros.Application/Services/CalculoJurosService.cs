using AutoMapper;
using CalculadoraJuros.Application.Services.Interfaces;
using CalculadoraJuros.Application.ViewModels;
using CalculadoraJuros.Domain.Business.Dto;
using CalculadoraJuros.Domain.Business.Interfaces;

namespace CalculadoraJuros.Application.Services
{
    public class CalculoJurosService : ICalculoJurosService
    {
        private readonly ICalculoJuros _calculoJurosBusiness;

        private readonly IMapper _mapper;

        public CalculoJurosService(ICalculoJuros calculoJurosBusiness, IMapper mapper)
        {
            _calculoJurosBusiness = calculoJurosBusiness;
            _mapper = mapper;
        }

        public decimal Calcular(CalculaJurosViewModel calculaJurosViewModel)
        {
            if (calculaJurosViewModel == null)
                throw new System.ArgumentNullException(nameof(calculaJurosViewModel));

            var informacoesCalculoJuros = _mapper.Map<InformacoesCalculoJuros>(calculaJurosViewModel);

            return _calculoJurosBusiness.Calcular(informacoesCalculoJuros);
        }
    }
}