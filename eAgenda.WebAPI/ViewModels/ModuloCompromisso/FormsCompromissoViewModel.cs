using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using System;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebAPI.ViewModels.ModuloCompromisso
{
    public class FormsCompromissoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Assunto { get; set; }

        public TipoLocalizacaoCompromissoEnum TipoLocalizacaoCompromisso { get; set; }
        public string Local { get; set; }
        public string Link { get; set; }

        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Contato Contato { get; set; }
        public Guid ContatoId { get; set; }
    }

    public class InserirCompromissoViewModel : FormsCompromissoViewModel
    {
    }

    public class EditarCompromissoViewModel : FormsCompromissoViewModel
    {
    }
}
