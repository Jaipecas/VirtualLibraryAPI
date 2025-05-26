using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.UserFriendFeatures
{
    public partial class DeleteFriendFeature
    {
        public class DeleteFriendCommand : IRequest<Result<bool>>
        {
            public string? UserId { get; set; }
            public string? FriendId { get; set; }
        }
    }
}
