using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class UpdateBoardFeature
    {
        public class UpdateBoardCommand : IRequest<Result<UpdateBoardDto>>
        {
            public int Id { get; set; }
            public string? Title { get; set; }
        }
    }
}
