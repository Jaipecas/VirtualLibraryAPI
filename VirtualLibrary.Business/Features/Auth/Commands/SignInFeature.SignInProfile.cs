
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInProfile : Profile
        {
            public SignInProfile()
            {
                CreateMap<IdentityUser, SignInDto>();
            }
        }
    }
}
