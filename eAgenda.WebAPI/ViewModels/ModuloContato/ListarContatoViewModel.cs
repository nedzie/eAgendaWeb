using System;

namespace eAgenda.WebAPI.ViewModels.ModuloContato
{
    public class ListarContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
