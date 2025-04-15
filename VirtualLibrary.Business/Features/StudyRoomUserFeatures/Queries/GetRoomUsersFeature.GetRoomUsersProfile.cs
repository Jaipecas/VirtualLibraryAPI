
using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature
    {
        public class GetRoomUsersProfile : Profile
        {
            public GetRoomUsersProfile()
            {
                CreateMap<User, GetRoomUsersUserDto>();  
            }
        }
    }
}
