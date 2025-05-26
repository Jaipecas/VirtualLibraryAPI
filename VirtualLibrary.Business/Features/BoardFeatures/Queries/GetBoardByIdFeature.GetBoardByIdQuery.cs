using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetBoardByIdFeature
    {
        public class GetBoardByIdQuery : IRequest<Result<GetBoardByIdDto>>
        {
            public int Id { get; set; }
        }

    }
}

