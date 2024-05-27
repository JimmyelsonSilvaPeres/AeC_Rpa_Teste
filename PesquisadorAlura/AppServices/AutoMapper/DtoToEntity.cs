using AppServices.DTO;
using AutoMapper;
using Domain.Entities;

namespace AppServices.AutoMapper
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity() 
        {
            CreateMap<ResultadoConsultaDTO, Resultado>()
                .ForPath(r => r.Professores, opt => opt.Ignore())
                .ForPath(r => r.Id, opt => opt.Ignore());

            CreateMap<Resultado, ResultadoConsultaDTO>()
                .ForPath(r => r.Professores, opt => opt.MapFrom( d => d.Professores.Select(p => p.Nome).ToList()));

        }
    }
}