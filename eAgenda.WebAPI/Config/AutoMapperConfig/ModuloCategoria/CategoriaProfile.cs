using AutoMapper;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.WebAPI.Config.AutoMapperConfig.ModuloAutenticacao;
using eAgenda.WebAPI.ViewModels.ModuloCategoria;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloCategoria
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<InserirCategoriaViewModel, Categoria>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>());

            CreateMap<EditarCategoriaViewModel, Categoria>();

            CreateMap<Categoria, ListarCategoriaViewModel>();
            CreateMap<Categoria, VisualizarCategoriaViewModel>();
        }
    }
}
