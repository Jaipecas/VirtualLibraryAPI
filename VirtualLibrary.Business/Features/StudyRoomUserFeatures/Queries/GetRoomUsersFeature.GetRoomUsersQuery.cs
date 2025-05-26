using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature
    {
        public class GetRoomUsersQuery : IRequest<Result<List<GetRoomUsersDto>>>
        {
            public required int RoomId { get; set; }
            public required bool IsConnected { get; set; }
        }
    }
}
