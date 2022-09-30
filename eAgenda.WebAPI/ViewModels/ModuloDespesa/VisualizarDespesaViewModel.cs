using System.Collections.Generic;
using System;

namespace eAgenda.WebAPI.ViewModels.ModuloDespesa
{
    public class VisualizarDespesaViewModel
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string FormaPagamento { get; set; }
        public List<string> Categorias { get; set; }
    }
}
