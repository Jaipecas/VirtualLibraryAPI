using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature
    {
        public class AddNotificationCommand : IRequest<Result<AddNotificationDto>>
        {
            public required string SenderId { get; set; }
            public required string RecipientName { get; set; }
            public required string Title { get; set; }
            public required string Message { get; set; }
            public required string NotificationType { get; set; }
            public int? RoomId { get; set; }
        }
    }
}
