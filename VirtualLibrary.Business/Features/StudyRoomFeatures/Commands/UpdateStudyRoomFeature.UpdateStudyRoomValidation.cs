using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature
    {
        public class UpdateStudyRoomValidation : AbstractValidator<UpdateStudyRoomCommand>
        {
            public UpdateStudyRoomValidation()
            {
                RuleFor(r => r.Id).NotEmpty();
                RuleFor(r => r.Name).NotEmpty();
                RuleFor(r => r.Description).NotEmpty();
                RuleFor(r => r.Pomodoro).NotEmpty()
                    .SetValidator(new UpdateStudyRoomPomodoroValidation())
                    .When(r => r.Pomodoro != null);
            }

            public class UpdateStudyRoomPomodoroValidation : AbstractValidator<PomodoroUpdateCommand>
            {
                public UpdateStudyRoomPomodoroValidation()
                {
                    RuleFor(r => r.PomodoroTime).NotEmpty();
                    RuleFor(r => r.BreakTime).NotEmpty();
                }
            }
        }

    }

}
