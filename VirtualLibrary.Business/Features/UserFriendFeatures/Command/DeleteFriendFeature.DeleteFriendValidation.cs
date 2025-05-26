
using FluentValidation;

namespace VirtualLibrary.Application.Features.UserFriendFeatures
{
    public partial class DeleteFriendFeature
    {
        public class DeleteFriendValidation : AbstractValidator<DeleteFriendCommand>
        {
            public DeleteFriendValidation()
            {
                RuleFor(r => r.UserId).NotEmpty();
                RuleFor(r => r.FriendId).NotEmpty();
            }
        }
    }
}
