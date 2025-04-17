using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.BoardFeatures
{
    public partial class AddBoardFeature
    {
        public class AddBoardCommand : IRequest<Result<AddBoardDto>>
        {
            public string? Title { get; set; }
        }

    }
}
