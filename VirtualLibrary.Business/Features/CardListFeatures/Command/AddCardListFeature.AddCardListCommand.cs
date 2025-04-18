using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class AddCardListFeature
    {
        public class AddCardListCommand : IRequest<Result<AddCardListDto>>
        {
            public int BoardId { get; set; }
            public string? Title { get; set; }
        }
    }
}
