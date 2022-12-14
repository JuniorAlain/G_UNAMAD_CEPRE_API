using AutoMapper;
using G_UNAMAD_CEPRE_API.Models;

namespace G_UNAMAD_CEPRE_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<G_CicloModelDTO, G_CicloModel>()
                .ForMember(d => d.IdCiclo, o => o.MapFrom(s => s.idCiclo))
                .ForMember(d => d.NCiclo, o => o.MapFrom(s => s.nCiclo))
                .ForMember(d => d.Periodo, o => o.MapFrom(s => s.periodo))
                .ForMember(d => d.FInicio, o => o.MapFrom(s => s.fInicio))
                .ForMember(d => d.FFin, o => o.MapFrom(s => s.fFin))
                .ForMember(d => d.EProgreso, o => o.MapFrom(s => s.eProgreso))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;
        }
    }
}
