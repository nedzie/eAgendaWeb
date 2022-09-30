using eAgenda.WebAPI.ViewModels.ModuloDespesa;
using System.Collections.Generic;

namespace eAgenda.WebAPI.ViewModels.ModuloCategoria
{
    public class VisualizarCategoriaViewModel
    {
        public string Titulo { get; set; }
        public List<ListarDespesaViewModel> Despesas { get; set; }
    }
}
