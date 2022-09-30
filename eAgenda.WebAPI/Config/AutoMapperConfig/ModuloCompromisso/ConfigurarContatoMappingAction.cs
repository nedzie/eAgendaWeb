using AutoMapper;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.WebAPI.ViewModels.ModuloCompromisso;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloCompromisso
{
    public class ConfigurarContatoMappingAction : IMappingAction<FormsCompromissoViewModel, Compromisso>
    {
        private readonly IRepositorioContato repositorioContato;

        public ConfigurarContatoMappingAction(IRepositorioContato repositorioContato)
        {
            this.repositorioContato = repositorioContato;
        }

        public void Process(FormsCompromissoViewModel compromissoVM, Compromisso compromisso, ResolutionContext context)
        {
            compromisso.Contato = repositorioContato.SelecionarPorId(compromissoVM.ContatoId);
        }
    }
}
