
using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class UpdateCardListFeature
    {
        public class UpdateCardListCommand : IRequest<Result<UpdateCardListDto>>
        {
            public int Id { get; set; }
            public string? Title { get; set; }
        }
    }
}
