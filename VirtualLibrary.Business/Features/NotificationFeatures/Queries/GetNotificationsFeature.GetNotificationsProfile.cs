
using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature
    {
        public class GetNotificationsProfile : Profile
        {
            public GetNotificationsProfile()
            {
                CreateMap<Notification, NotificationDto>()
                    .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName));

            }
        }
    }
}
