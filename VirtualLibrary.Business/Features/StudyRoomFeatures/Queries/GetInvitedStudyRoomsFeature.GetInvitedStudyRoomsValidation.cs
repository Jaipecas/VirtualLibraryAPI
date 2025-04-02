using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetInvitedStudyRoomsFeature
    {
        public class GetInvitedStudyRoomsValidation : AbstractValidator<GetInvitedStudyRoomsQuery>
        {
            public GetInvitedStudyRoomsValidation()
            {
                RuleFor(r => r.UserId).NotEmpty();
            }
        }
    }
}
