using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public partial class UpdateUserProfile : Profile
        {
            public UpdateUserProfile()
            {
                CreateMap<User, UpdateUserDto>();
            }
        }
    }
}
