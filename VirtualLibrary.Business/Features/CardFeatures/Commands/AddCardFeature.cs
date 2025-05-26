
using MediatR;
using VirtualLibrary.Domain.Common;
using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.AddCardFeature;
using VirtualLibrary.Application.Persistence;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class AddCardFeature : IRequestHandler<AddCardCommand, Result<AddCardDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCardFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<AddCardDto>> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            var cardList = await _unitOfWork.CardLists.GetById(request.CardListId);

            if (cardList == null) return Result<AddCardDto>.Failure($"No existe la card list con id: {request.CardListId}");

            var card = _mapper.Map<Card>(request);

            await _unitOfWork.Cards.Add(card);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddCardDto>(card);

            return Result<AddCardDto>.Success(result);
        }
    }
}
