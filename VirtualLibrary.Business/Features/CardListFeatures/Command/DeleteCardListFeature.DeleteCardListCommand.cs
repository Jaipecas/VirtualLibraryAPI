using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class DeleteCardListFeature
    {
        public class DeleteCardListCommand : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
    }
}
