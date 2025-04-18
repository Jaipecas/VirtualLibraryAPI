
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.CardListFeatures.Command.DeleteCardListFeature;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class DeleteCardListFeature : IRequestHandler<DeleteCardListCommand, Result<bool>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteCardListFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteCardListCommand request, CancellationToken cancellationToken)
        {
            var cardList = await _unitOfWork.CardLists.GetById(request.Id);

            if (cardList == null) Result<bool>.Failure($"No existe un card list con id: {request.Id}");

            await _unitOfWork.CardLists.Delete(cardList!.Id);

            await _unitOfWork.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
