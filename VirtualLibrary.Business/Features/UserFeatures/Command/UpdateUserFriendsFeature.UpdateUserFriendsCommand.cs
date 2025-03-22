using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.UserFeatures.Command
{
    public partial class UpdateUserFriendsFeature
    {
        public class UpdateUserFriendsCommand : IRequest<IActionResult>
        {
            public required string UserId { get; set; }
            public required string FriendId { get; set; }
        }




    }
}
