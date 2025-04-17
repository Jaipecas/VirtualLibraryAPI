using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class DeleteBoardFeature
    {
        public class DeleteBoardCommand : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
    }
}
