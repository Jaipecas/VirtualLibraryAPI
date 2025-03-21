using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature
    {
        public class GetStudyRoomsByOwnerValidation : AbstractValidator<GetStudyRoomsByOwnerQuery>
        {
            public GetStudyRoomsByOwnerValidation()
            {
                RuleFor(r => r.UserId).NotEmpty();
            }
        }
    }
}
