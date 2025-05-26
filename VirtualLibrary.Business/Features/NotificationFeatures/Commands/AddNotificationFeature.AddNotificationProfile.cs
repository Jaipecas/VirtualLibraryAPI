
using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature
    {
        public class AddNotificationProfile : Profile
        {
            public AddNotificationProfile()
            {
                CreateMap<AddNotificationCommand, Notification>();
                CreateMap<AddNotificationCommand, RoomNotification>();
                CreateMap<AddNotificationCommand, FriendNotification>();
                CreateMap<Notification, AddNotificationDto>();
            }
        }
    }
}

