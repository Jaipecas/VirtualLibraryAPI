
using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class DeleteStudyRoomFeature
    {
        public class DeleteStudyRoomUserValidation : AbstractValidator<DeleteStudyRoomUserCommand>
        {
            public DeleteStudyRoomUserValidation()
            {
                RuleFor(r => r.RoomId).NotEmpty().GreaterThan(0);
                RuleFor(r => r.UserId).NotEmpty();
            }
        }
    }
}
