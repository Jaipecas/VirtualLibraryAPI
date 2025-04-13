
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands.UpdateStudyRoomUserFeature;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature : IRequestHandler<UpdateStudyRoomUserCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudyRoomUserFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Handle(UpdateStudyRoomUserCommand request, CancellationToken cancellationToken)
        {
            var roomUser = await _unitOfWork.StudyRoomUser.GetById(request.RoomUserId);

            if (roomUser == null) return new NotFoundObjectResult(new { ErrorMessage = "No se ha encontrado el usuario en la sala" });

            roomUser.IsConnected = request.IsConnected;

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateStudyRoomUserDto>(roomUser);

            return new OkObjectResult(result);
        }
    }
}

