
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature
    {
        public class GetStudyRoomsByOwnerQuery : IRequest<Result<List<StudyRoomDto>>>
        {
            public required string UserId { get; set; }
        }
    }
}
