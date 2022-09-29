using eAgenda.Dominio.ModuloContato;
using System;

namespace eAgenda.WebAPI.ViewModels.ModuloCompromisso
{
    public class VisualizarCompromissoViewModel
    {
        public string Assunto { get; set; }
        public string TipoLocalizacaoCompromisso { get; set; }
        public string Local { get; set; }
        public string Link { get; set; }

        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Contato Contato { get; set; }
        public Guid ContatoId { get; set; }
    }
}
