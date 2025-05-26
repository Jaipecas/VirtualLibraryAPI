
using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpProfile : Profile
        {
            public SignUpProfile()
            {
                CreateMap<User, SignUpDto>();
            }
        }
    }

}
