
using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class UpdateCardFeature
    {
        public class UpdateCardCommand : IRequest<Result<UpdateCardDto>>
        {
            public int Id { get; set; }
            public int? CardListId { get; set; }
            public string? Title { get; set; }
            public bool? IsComplete { get; set; }
            public int? Order {  get; set; }
        }
    }
}
