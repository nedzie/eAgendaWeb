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
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());

            CreateMap<EditarCompromissoViewModel, Compromisso>();
            CreateMap<Compromisso, ListarCompromissoViewModel>();
            CreateMap<Compromisso, VisualizarCompromissoViewModel>();
        }
    }
}
