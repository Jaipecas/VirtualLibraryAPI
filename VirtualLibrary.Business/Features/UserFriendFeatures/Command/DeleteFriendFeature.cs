using MediatR;
using System.Data.SqlTypes;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.UserFriendFeatures.DeleteFriendFeature;

namespace VirtualLibrary.Application.Features.UserFriendFeatures
{
    public partial class DeleteFriendFeature : IRequestHandler<DeleteFriendCommand, Result<bool>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteFriendFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Result<bool>> IRequestHandler<DeleteFriendCommand, Result<bool>>.Handle(DeleteFriendCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserFriends.RemoveFriend(request.UserId!, request.FriendId!);

            await _unitOfWork.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
