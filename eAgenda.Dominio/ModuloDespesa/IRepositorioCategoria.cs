using eAgenda.Dominio.Compartilhado;
using System.Collections.Generic;
using System;

namespace eAgenda.Dominio.ModuloDespesa
{
    public interface IRepositorioCategoria : IRepositorio<Categoria>
    {
        List<Categoria> SelecionarTodos(Guid guid);
    }
}
