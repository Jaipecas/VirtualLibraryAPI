using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserValidation : AbstractValidator<UpdateStudyRoomUserCommand>
        {
            public UpdateStudyRoomUserValidation()
            {
                RuleFor(r => r.RoomId).NotEmpty().GreaterThan(0);
                RuleFor(r => r.UserId).NotEmpty();
            }
        }
    }
}

