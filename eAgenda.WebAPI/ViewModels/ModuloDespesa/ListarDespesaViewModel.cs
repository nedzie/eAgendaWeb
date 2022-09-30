﻿using System;

namespace eAgenda.WebAPI.ViewModels.ModuloDespesa
{
    public class ListarDespesaViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string FormaPagamento { get; set; }
    }
}
