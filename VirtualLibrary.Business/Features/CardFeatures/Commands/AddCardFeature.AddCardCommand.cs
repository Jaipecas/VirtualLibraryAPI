
using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class AddCardFeature
    {
        public class AddCardCommand : IRequest<Result<AddCardDto>>
        {
            public int CardListId { get; set; }
            public string? Title { get; set; }
            public int? Order {  get; set; }
        }
    }
}
