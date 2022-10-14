using AutoMapper;
using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.WebAPI.Config.AutoMapperConfig.ModuloAutenticacao;
using eAgenda.WebAPI.ViewModels.ModuloTarefa;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloTarefa
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            // Classe => ViewModel
            CreateMap<Tarefa, ListarTarefaViewModel>() // ForMember para as propriedades com nomes diferentes entre as classes
                    .ForMember(destino => destino.Prioridade, opt => opt.MapFrom(origem => origem.Prioridade.GetDescription()))
                    .ForMember(destino => destino.Situacao, opt =>
                        opt.MapFrom(origem => origem.PercentualConcluido == 100 ? "Concluída" : "Pendente"));

            CreateMap<Tarefa, VisualizarTarefaViewModel>()
                .ForMember(destino => destino.Prioridade, opt => opt.MapFrom(origem => origem.Prioridade.GetDescription()))
                .ForMember(destino => destino.Situacao, opt =>
                    opt.MapFrom(origem => origem.PercentualConcluido == 100 ? "Concluída" : "Pendente"))
                .ForMember(destino => destino.QtdeItens, opt => opt.MapFrom(origem => origem.Itens.Count));

            CreateMap<ItemTarefa, VisualizarItemTarefaViewModel>()
                .ForMember(destino => destino.Situacao, opt => opt.MapFrom(origem => origem.Concluido ? "Concluído" : "Pendente"));

            CreateMap<Tarefa, FormsTarefaViewModel>();

            CreateMap<ItemTarefa, FormsItemTarefaViewModel>();


            // ViewModel => Classe
            CreateMap<InserirTarefaViewModel, Tarefa>()
                .ForMember(destino => destino.UsuarioId, opt => opt.MapFrom<UsuarioResolver>())
                .ForMember(destino => destino.Itens, opt => opt.Ignore())
                .AfterMap<AdicionarItensMappingAction>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<EditarTarefaViewModel, Tarefa>()
                .ForMember(destino => destino.Itens, opt => opt.Ignore())
                .AfterMap<EditarItensMappingAction>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());
        }
    }

    public class AdicionarItensMappingAction : IMappingAction<InserirTarefaViewModel, Tarefa>
    {
        public void Process(InserirTarefaViewModel viewModel, Tarefa tarefa, ResolutionContext context)
        {
            if (viewModel.Itens == null)
                return;

            foreach (var itemVM in viewModel.Itens)
            {
                var item = new ItemTarefa
                {
                    Titulo = itemVM.Titulo
                };

                tarefa.AdicionarItem(item);
            }
        }
    }

    public class EditarItensMappingAction : IMappingAction<EditarTarefaViewModel, Tarefa>
    {
        public void Process(EditarTarefaViewModel viewModel, Tarefa tarefa, ResolutionContext context)
        {
            foreach (var itemVM in viewModel.Itens)
                if (itemVM.Concluido)
                    tarefa.ConcluirItem(itemVM.Id);
                else
                    tarefa.MarcarPendente(itemVM.Id);

            foreach (var itemVM in viewModel.Itens)
                if (itemVM.Status == StatusItemTarefa.Adicionado)
                    tarefa.AdicionarItem(new ItemTarefa(itemVM.Titulo));
                else if (itemVM.Status == StatusItemTarefa.Removido)
                    tarefa.RemoverItem(itemVM.Id);
        }
    }
}
