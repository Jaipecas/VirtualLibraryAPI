using FluentValidation;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature
    {
        public class GetRoomUsersValidation : AbstractValidator<GetRoomUsersQuery>
        {
            public GetRoomUsersValidation()
            {
                RuleFor(r => r.RoomId).NotEmpty();
            }
        }
    }
}
