using MediatR;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.AddStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures
{
    public partial class AddStudyRoomFeature : IRequestHandler<AddStudyRoomCommand>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        
        public AddStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(AddStudyRoomCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
