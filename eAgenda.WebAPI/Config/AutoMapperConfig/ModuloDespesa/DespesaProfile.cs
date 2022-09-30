using AutoMapper;
using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.WebAPI.ViewModels.ModuloDespesa;
using System.Linq;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloDespesa
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<InserirDespesaViewModel, Despesa>();
            CreateMap<EditarDespesaViewModel, Despesa>();

            CreateMap<Despesa, ListarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()));

            CreateMap<Despesa, VisualizarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()))
                .ForMember(destino => destino.Categorias, opt =>
                    opt.MapFrom(origem => origem.Categorias.Select(x => x.Titulo)));
        }
    }
}
