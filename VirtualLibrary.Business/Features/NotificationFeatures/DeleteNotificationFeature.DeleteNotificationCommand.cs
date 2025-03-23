using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature
    {
        public class DeleteNotificationCommand : IRequest<IActionResult>
        {
            public required int Id { get; set; }
            public required bool IsAccepted { get; set; }
        }
    }
}
