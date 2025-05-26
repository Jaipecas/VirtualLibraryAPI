using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetInvitedStudyRoomsFeature
    {
        public class GetInvitedStudyRoomsQuery : IRequest<Result<List<GetInvitedStudyRoomsDto>>>
        {
            public required string UserId { get; set; }
        }
    }
}
