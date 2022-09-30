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
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());

            CreateMap<EditarContatoViewModel, Contato>();

            CreateMap<Contato, ListarContatoViewModel>();

            CreateMap<Contato, VisualizarContatoViewModel>();
        }
    }
}
