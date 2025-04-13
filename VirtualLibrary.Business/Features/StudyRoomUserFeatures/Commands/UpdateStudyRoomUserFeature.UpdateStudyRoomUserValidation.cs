using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserValidation : AbstractValidator<UpdateStudyRoomUserCommand>
        {
            public UpdateStudyRoomUserValidation()
            {
                RuleFor(r => r.RoomUserId).NotEmpty().GreaterThan(0);
            }
        }
    }
}

