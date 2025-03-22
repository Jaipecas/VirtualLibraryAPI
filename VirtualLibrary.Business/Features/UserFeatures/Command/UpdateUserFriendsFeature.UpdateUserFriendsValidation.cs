using FluentValidation;

namespace VirtualLibrary.Application.Features.UserFeatures.Command
{
    public partial class UpdateUserFriendsFeature
    {
        public class UpdateUserFriendsValidation : AbstractValidator<UpdateUserFriendsCommand>
        {
            public UpdateUserFriendsValidation()
            {
                RuleFor(r => r.UserId).NotEmpty();
                RuleFor(r => r.FriendId).NotEmpty();
            }
        }




    }
}
