using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands.DeleteStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class DeleteStudyRoomFeature : IRequestHandler<DeleteStudyRoomUserCommand, Result<bool>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteStudyRoomUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StudyRoomUser.DeleteRoomUsers((int)request.RoomId!, [request.UserId]);

            await _unitOfWork.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
