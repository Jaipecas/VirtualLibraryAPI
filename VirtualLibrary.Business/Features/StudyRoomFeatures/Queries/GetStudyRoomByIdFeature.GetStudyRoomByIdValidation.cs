using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature
    {
        public class GetStudyRoomByIdValidation : AbstractValidator<GetStudyRoomByIdQuery>
        {
            public GetStudyRoomByIdValidation()
            {
                RuleFor(r => r.RoomId).NotEmpty();
            }
        }
    }
}
