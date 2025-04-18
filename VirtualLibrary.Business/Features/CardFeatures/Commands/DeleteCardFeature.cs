using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.DeleteCardFeature;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class DeleteCardFeature : IRequestHandler<DeleteCardCommand, Result<bool>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteCardFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.Cards.GetById(request.Id);

            if (card == null) Result<bool>.Failure($"No existe una card con id: {request.Id}");

            await _unitOfWork.Cards.Delete(card!.Id);

            await _unitOfWork.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
