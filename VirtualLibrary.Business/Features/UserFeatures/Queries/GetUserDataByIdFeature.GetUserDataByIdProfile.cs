
using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature
    {
        public class GetUserDataByIdProfile : Profile
        {
            public GetUserDataByIdProfile()
            {
                CreateMap<User, GetUserDataByIdDto>()
                     .ForMember(dest => dest.Friends, opt => opt.MapFrom(src => src.UserFriends.Select(uf => uf.Friend)));

                CreateMap<User, GetUserDataByIdFriendDto>();
            }
        }
    }
}
