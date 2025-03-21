
using AutoMapper;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserByNameFeature
    {
        public class GGetUserByNameProfile : Profile
        {
            public GGetUserByNameProfile()
            {
                CreateMap<User, GetUserByNameDto>();
            }
        }
    }
}
