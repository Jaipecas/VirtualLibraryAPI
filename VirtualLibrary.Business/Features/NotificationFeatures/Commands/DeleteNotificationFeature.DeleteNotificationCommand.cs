using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature
    {
        public class DeleteNotificationCommand : IRequest<Result<DeleteNotificationDto>>
        {
            public required int Id { get; set; }
            public required bool IsAccepted { get; set; }
            public required string NotificationType { get; set; }    
        }
    }
}
