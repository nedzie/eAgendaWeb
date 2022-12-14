using eAgenda.Dominio.ModuloContato;
using System;

namespace eAgenda.WebAPI.ViewModels.ModuloCompromisso
{
    public class ListarCompromissoViewModel
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public Contato Contato { get; set; }
        public Guid ContatoId { get; set; }
    }
}
