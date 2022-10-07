using AutoMapper;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.WebAPI.ViewModels.ModuloTarefa;
using System;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloTarefa
{
    public class AdicionarGuidMappingAction : IMappingAction<InserirTarefaViewModel, Tarefa>
    {
        public void Process(InserirTarefaViewModel source, Tarefa destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
