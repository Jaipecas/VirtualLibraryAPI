
using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInProfile : Profile
        {
            public SignInProfile()
            {
                CreateMap<User, SignInDto>();
            }
        }
    }
}
