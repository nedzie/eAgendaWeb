using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloAutenticacao
{

    public class UsuarioResolver : IValueResolver<object, object, Guid>
    {
        private readonly IHttpContextAccessor httpContextAcessor;

        public UsuarioResolver(IHttpContextAccessor httpContextAcessor)
        {
            this.httpContextAcessor = httpContextAcessor;
        }

        public Guid Resolve(object source, object destination, Guid destMember, ResolutionContext context)
        {
            var id = httpContextAcessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(id))
                throw new InvalidOperationException("O id do usuário não foi encontrado");

            return Guid.Parse(id);
        }
    }
}
