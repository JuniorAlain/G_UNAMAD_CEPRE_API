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

            CreateMap<G_CursoModelDTO, G_CursoModel>()
                .ForMember(d => d.IdCurso, o => o.MapFrom(s => s.idCurso))
                .ForMember(d => d.NCurso, o => o.MapFrom(s => s.nCurso))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;

            CreateMap<G_CarreraModelDTO, G_CarreraModel>()
                .ForMember(d => d.IdCarrera, o => o.MapFrom(s => s.idCarrera))
                .ForMember(d => d.NCarrera, o => o.MapFrom(s => s.nCarrera))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;

            CreateMap<G_GrupoModelDTO, G_GrupoModel>()
                .ForMember(d => d.IdGrupo, o => o.MapFrom(s => s.idGrupo))
                .ForMember(d => d.NGrupo, o => o.MapFrom(s => s.nGrupo))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;

            CreateMap<G_TemaModelDTO, G_TemaModel>()
                .ForMember(d => d.IdTema, o => o.MapFrom(s => s.idTema))
                .ForMember(d => d.NTema, o => o.MapFrom(s => s.nTema))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;

            CreateMap<G_TurnoModelDTO, G_TurnoModel>()
                .ForMember(d => d.IdTurno, o => o.MapFrom(s => s.idTurno))
                .ForMember(d => d.NTurno, o => o.MapFrom(s => s.nTurno))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;

            CreateMap<G_AulaModelDTO, G_AulaModel>()
                .ForMember(d => d.IdAula, o => o.MapFrom(s => s.idAula))
                .ForMember(d => d.NAula, o => o.MapFrom(s => s.nAula))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;

            CreateMap<G_ModalidadModelDTO, G_ModalidadModel>()
                .ForMember(d => d.IdModalidad, o => o.MapFrom(s => s.idModalidad))
                .ForMember(d => d.NModalidad, o => o.MapFrom(s => s.nModalidad))
                .ForMember(d => d.Activo, o => o.MapFrom(s => s.activo))
            ;
        }        
    }
}
