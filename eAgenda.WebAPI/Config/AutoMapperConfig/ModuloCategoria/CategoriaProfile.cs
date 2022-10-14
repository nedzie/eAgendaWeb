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
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<EditarCategoriaViewModel, Categoria>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<Categoria, ListarCategoriaViewModel>();
            CreateMap<Categoria, VisualizarCategoriaViewModel>();

            CreateMap<Categoria, FormsCategoriaViewModel>();
        }
    }
}
