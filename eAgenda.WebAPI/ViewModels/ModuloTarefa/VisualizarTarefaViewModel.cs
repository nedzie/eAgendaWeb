using System;
using System.Collections.Generic;

namespace eAgenda.WebAPI.ViewModels.ModuloTarefa
{
    public class VisualizarTarefaViewModel
    {
        public VisualizarTarefaViewModel()
        {
            Itens = new();
        }
        public Guid Id { get; set; }

        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Prioridade { get; set; }
        public string Situacao { get; set; }
        public int QtdeItens { get; set; }
        public decimal PercentualConcluido { get; set; }
        public List<VisualizarItemTarefaViewModel> Itens { get; set; }
    }
}
