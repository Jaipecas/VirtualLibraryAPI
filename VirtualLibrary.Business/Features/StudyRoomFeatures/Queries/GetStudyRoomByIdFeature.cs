
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomByIdFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature : IRequestHandler<GetStudyRoomByIdQuery, Result<GetStudyRoomByIdDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudyRoomByIdFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task< Result<GetStudyRoomByIdDto>> Handle(GetStudyRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.StudyRooms.GetById(request.RoomId);

            if (room == null) return Result<GetStudyRoomByIdDto>.Failure("La sala no existe");

            var result = _mapper.Map<GetStudyRoomByIdDto>(room);

            return Result<GetStudyRoomByIdDto>.Success(result);
        }
    }
}
