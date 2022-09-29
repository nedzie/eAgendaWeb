using AutoMapper;
using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloTarefa;
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



            // ViewModel => Classe

            CreateMap<InserirTarefaViewModel, Tarefa>()
                .ForMember(destino => destino.Itens, opt => opt.Ignore())
                .AfterMap((viewModel, tarefa) =>
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
                });

            CreateMap<EditarTarefaViewModel, Tarefa>()
                .ForMember(destino => destino.Itens, opt => opt.Ignore())
                .AfterMap((viewModel, tarefa) =>
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
                });
        }
    }
}
