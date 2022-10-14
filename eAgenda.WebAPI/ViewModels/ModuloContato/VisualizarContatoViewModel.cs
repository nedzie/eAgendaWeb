﻿using System;

namespace eAgenda.WebAPI.ViewModels.ModuloContato
{
    public class VisualizarContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
    }
}
