
using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public class AddStudyRoomValidation : AbstractValidator<AddStudyRoomCommand>
        {
            public AddStudyRoomValidation()
            {
                RuleFor(r => r.Name).NotEmpty();
                RuleFor(r => r.Description).NotEmpty();                
                RuleFor(r => r.Pomodoro).NotEmpty().SetValidator(new AddStudyRoomPomodoroValidation());
            }

            public class AddStudyRoomPomodoroValidation : AbstractValidator<PomodoroCommand>
            {
                public AddStudyRoomPomodoroValidation()
                {
                    RuleFor(r => r.PomodoroTime).NotEmpty();
                    RuleFor(r => r.BreakTime).NotEmpty();
                }
            }
        }
    }
}
