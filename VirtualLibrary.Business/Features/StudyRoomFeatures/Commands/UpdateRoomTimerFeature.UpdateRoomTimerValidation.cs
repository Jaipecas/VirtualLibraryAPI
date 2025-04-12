using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature
    {
        public class UpdateRoomTimerValidation : AbstractValidator<UpdateRoomTimerCommand>
        {
            public UpdateRoomTimerValidation()
            {
                RuleFor(r => r.RoomId).NotEmpty();
            }          
        }
    }
}
