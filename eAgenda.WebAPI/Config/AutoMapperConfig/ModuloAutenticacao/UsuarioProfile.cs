using AutoMapper;
using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.WebAPI.ViewModels.ModuloAutenticacao;

namespace eAgenda.WebAPI.Config.AutoMapperConfig.ModuloAutenticacao
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(destino => destino.EmailConfirmed, opt => opt.MapFrom(origem => true))
                .ForMember(destino => destino.UserName, opt => opt.MapFrom(origem => origem.Email));
        }
    }
}
