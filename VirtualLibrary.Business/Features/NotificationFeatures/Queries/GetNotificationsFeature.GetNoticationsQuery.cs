using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature
    {
        public class GetNoticationsQuery : IRequest<Result<List<NotificationDto>>>
        {
            public required string UserId { get; set; }
        }
    }
}
