
using MediatR;
using VirtualLibrary.Domain.Common;
using AutoMapper;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.CardListFeatures.Command.UpdateCardListFeature;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class UpdateCardListFeature : IRequestHandler<UpdateCardListCommand, Result<UpdateCardListDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCardListFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UpdateCardListDto>> Handle(UpdateCardListCommand request, CancellationToken cancellationToken)
        {
            var cardList = await _unitOfWork.CardLists.GetById(request.Id);

            if (cardList == null) return Result<UpdateCardListDto>.Failure("La card list no existe");

            cardList.Title = request.Title!;

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateCardListDto>(cardList);

            return Result<UpdateCardListDto>.Success(result);
        }
    }
}
