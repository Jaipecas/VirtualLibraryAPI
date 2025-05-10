using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetInvitedStudyRoomsFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetInvitedStudyRoomsFeature : IRequestHandler<GetInvitedStudyRoomsQuery, Result<List<GetInvitedStudyRoomsDto>>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInvitedStudyRoomsFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetInvitedStudyRoomsDto>>> Handle(GetInvitedStudyRoomsQuery request, CancellationToken cancellationToken)
        {
            var roomsUser = await _unitOfWork.StudyRoomUser.GetRoomsByUser(request.UserId);

            if (roomsUser == null) return Result<List<GetInvitedStudyRoomsDto>>.Failure("No se han encontrado salas");

            List<StudyRoom> rooms = [];

            if (roomsUser.Count > 0) rooms = roomsUser.Select(roomUser => roomUser.StudyRoom).ToList();

            var result = _mapper.Map<List<GetInvitedStudyRoomsDto>>(rooms);

            return Result<List<GetInvitedStudyRoomsDto>>.Success(result);
        }
    }
}
