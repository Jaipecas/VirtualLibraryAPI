using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetAllBoardsFeature
    {
        public class GetAllBoardsQuery : IRequest<Result<List<GetAllBoardsDto>>>
        {
            public string? UserId { get; set; }
        }
    }
}
