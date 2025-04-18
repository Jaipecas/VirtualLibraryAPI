
using MediatR;
using VirtualLibrary.Domain.Common;
using AutoMapper;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.UpdateCardFeature;
using VirtualLibrary.Application.Persistence;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class UpdateCardFeature : IRequestHandler<UpdateCardCommand, Result<UpdateCardDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCardFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UpdateCardDto>> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.Cards.GetById(request.Id);

            if (card == null) return Result<UpdateCardDto>.Failure($"La card no existe con id {request.Id}");

            var cardList = await _unitOfWork.CardLists.GetById(request.CardListId);

            if (cardList == null) return Result<UpdateCardDto>.Failure($"La card list no existe con id {request.CardListId}");

            card.Title = request.Title!;
            card.CardListId = request.CardListId;
            card.IsComplete = request.IsComplete;

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateCardDto>(card);

            return Result<UpdateCardDto>.Success(result);
        }
    }
}
