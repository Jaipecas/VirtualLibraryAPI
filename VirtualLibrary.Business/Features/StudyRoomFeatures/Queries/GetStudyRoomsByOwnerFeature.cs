using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomsByOwnerFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature : IRequestHandler<GetStudyRoomsByOwnerQuery, Result<List<StudyRoomDto>>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudyRoomsByOwnerFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<StudyRoomDto>>> Handle(GetStudyRoomsByOwnerQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId);

            if (user == null) return Result<List<StudyRoomDto>>.Failure("Usuario no encontrado");

            var rooms = user.StudyRooms;

            if (rooms == null) return Result<List<StudyRoomDto>>.Failure("El usuario no tiene salas");

            var result = _mapper.Map<List<StudyRoomDto>>(rooms);

            return Result<List<StudyRoomDto>>.Success(result);
        }
    }
}
