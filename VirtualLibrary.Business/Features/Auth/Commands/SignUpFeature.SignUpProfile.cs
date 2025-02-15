
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpProfile : Profile
        {
            public SignUpProfile()
            {
                CreateMap<IdentityUser, SignUpDto>();
            }
        }
    }

}
