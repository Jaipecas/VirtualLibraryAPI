using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class DeleteCardFeature
    {
        public class DeleteCardCommand : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
    }
}
