using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature
    {
        public class AddNotificationCommand : IRequest<IActionResult>
        {
            public required string SenderId { get; set; }
            public required string RecipientId { get; set; }
            public required string Title { get; set; }
            public required string Message { get; set; }
            public required string NotificationType { get; set; }
            public int? RoomId { get; set; }
        }
    }
}
