﻿using System;

namespace eAgenda.WebAPI.ViewModels.ModuloDespesa
{
    public class CategoriaSelecionadaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool Selecionada { get; set; }
    }
}
