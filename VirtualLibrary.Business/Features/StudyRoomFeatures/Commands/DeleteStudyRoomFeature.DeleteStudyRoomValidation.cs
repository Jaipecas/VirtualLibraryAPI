using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class DeleteStudyRoomFeature
    {
        public class DeleteStudyRoomValidation : AbstractValidator<DeleteStudyRoomCommand>
        {
            public DeleteStudyRoomValidation()
            {
                RuleFor(r => r.StudyRoomId).NotEmpty();
            }
        }
    }
}
