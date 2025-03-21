using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomsByOwnerFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature : IRequestHandler<GetStudyRoomsByOwnerQuery, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudyRoomsByOwnerFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetStudyRoomsByOwnerQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId);

            if (user == null) return new NotFoundObjectResult(new { errorMessage = "Usuario no encontrado" });

            var rooms = user.StudyRooms;

            if (rooms == null) return new NotFoundObjectResult(new { errorMessage = "El usuario no tiene salas" });

            var result = _mapper.Map<List<StudyRoomDto>>(rooms);

            return new OkObjectResult(result);
        }
    }
}
