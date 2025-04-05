
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomByIdFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature : IRequestHandler<GetStudyRoomByIdQuery, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudyRoomByIdFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetStudyRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.StudyRooms.GetById(request.RoomId);

            if (room == null) return new NotFoundObjectResult(new { ErrorMessage = "La sala no existe" });

            var result = _mapper.Map<GetStudyRoomByIdDto>(room);

            return new OkObjectResult(result);
        }
    }
}
