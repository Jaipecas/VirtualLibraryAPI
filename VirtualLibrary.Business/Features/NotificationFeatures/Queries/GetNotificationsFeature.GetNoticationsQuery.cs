using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature
    {
        public class GetNoticationsQuery : IRequest<IActionResult>
        {
            public required string UserId { get; set; }
        }
    }
}
