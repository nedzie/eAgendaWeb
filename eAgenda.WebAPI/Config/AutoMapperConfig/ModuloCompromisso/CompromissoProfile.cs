using AutoMapper;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.WebAPI.Config.AutoMapperConfig.ModuloAutenticacao;
using eAgenda.WebAPI.ViewModels.ModuloCompromisso;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloCompromisso
{
    public class CompromissoProfile : Profile
    {
        public CompromissoProfile()
        {
            CreateMap<InserirCompromissoViewModel, Compromisso>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .ForMember(destino => destino.TipoLocalizacaoCompromisso, opt => opt.MapFrom(origem => origem.TipoLocalizacaoCompromisso))
                .AfterMap<ConfigurarContatoMappingAction>();

            CreateMap<EditarCompromissoViewModel, Compromisso>()
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .AfterMap<ConfigurarContatoMappingAction>();


            CreateMap<Compromisso, ListarCompromissoViewModel>();
            CreateMap<Compromisso, VisualizarCompromissoViewModel>();

            CreateMap<Compromisso, FormsCompromissoViewModel>();
        }
    }
}
