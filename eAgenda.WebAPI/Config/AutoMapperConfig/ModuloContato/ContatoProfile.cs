using AutoMapper;
using eAgenda.Dominio.ModuloContato;
using eAgenda.WebAPI.Config.AutoMapperConfig.ModuloAutenticacao;
using eAgenda.WebAPI.ViewModels.ModuloContato;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloContato
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<InserirContatoViewModel, Contato>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<EditarContatoViewModel, Contato>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<Contato, ListarContatoViewModel>();

            CreateMap<Contato, VisualizarContatoViewModel>();

            CreateMap<Contato, FormsContatoViewModel>();
        }
    }
}
