using Microsoft.AspNetCore.Identity;
using System;

namespace eAgenda.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid> // Para trocar o ID de string para GUID
    {
        public string Nome { get; set; }
    }
}
