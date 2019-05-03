using AutoMapper;
using CalculadoraJuros.Application.ViewModels;
using CalculadoraJuros.Domain.Business.Dto;

namespace CalculadoraJuros.Application.AutoMapper
{
    public class ViewModelToBusinessDtoMappingProfile : Profile
    {
        public ViewModelToBusinessDtoMappingProfile()
        {
            CreateMap<CalculaJurosViewModel, InformacoesCalculoJuros>();                                
        }
    }
}