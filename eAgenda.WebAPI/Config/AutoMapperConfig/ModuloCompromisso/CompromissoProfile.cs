using AutoMapper;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.WebAPI.ViewModels.ModuloCompromisso;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloCompromisso
{
    public class CompromissoProfile : Profile
    {
        public CompromissoProfile()
        {
            CreateMap<Compromisso, ListarCompromissoViewModel>();
            CreateMap<Compromisso, VisualizarCompromissoViewModel>();
            CreateMap<InserirCompromissoViewModel, Compromisso>();
            CreateMap<EditarCompromissoViewModel, Compromisso>();
        }
    }
}
