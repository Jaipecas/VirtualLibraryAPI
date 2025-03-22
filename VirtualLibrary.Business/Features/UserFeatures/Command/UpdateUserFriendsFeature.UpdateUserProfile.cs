
using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.UserFeatures.Command
{
    public partial class UpdateUserFriendsFeature
    {
        public class UpdateUserProfile : Profile
        {
            public UpdateUserProfile()
            {
                CreateMap<User, UpdateUserFriendsDto>();
            }
        }
    }
}
