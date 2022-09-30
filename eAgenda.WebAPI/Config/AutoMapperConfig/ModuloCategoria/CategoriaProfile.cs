using AutoMapper;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.WebAPI.ViewModels.ModuloCategoria;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloCategoria
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<InserirCategoriaViewModel, Categoria>();
            CreateMap<EditarCategoriaViewModel, Categoria>();

            CreateMap<Categoria, ListarCategoriaViewModel>();
            CreateMap<Categoria, VisualizarCategoriaViewModel>();
        }
    }
}
