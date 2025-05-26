
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.BoardEntities;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.AddCardFeature;
using static VirtualLibrary.Application.Features.CardListFeatures.Command.AddCardListFeature;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class AddCardListFeature : IRequestHandler<AddCardListCommand, Result<AddCardListDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCardListFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<AddCardListDto>> Handle(AddCardListCommand request, CancellationToken cancellationToken)
        {
            var board = await _unitOfWork.Boards.GetById(request.BoardId);

            if (board == null) return Result<AddCardListDto>.Failure($"No existe el board con id: {request.BoardId}");

            var cardList = _mapper.Map<CardList>(request);

            await _unitOfWork.CardLists.Add(cardList);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddCardListDto>(cardList);

            return Result<AddCardListDto>.Success(result);
        }
    }
}
