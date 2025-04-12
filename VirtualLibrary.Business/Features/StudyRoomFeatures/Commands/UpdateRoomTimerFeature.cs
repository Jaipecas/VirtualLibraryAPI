
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateRoomTimerFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature : IRequestHandler<UpdateRoomTimerCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoomTimerFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UpdateRoomTimerCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.StudyRooms.GetById(request.RoomId);

            if (room == null) return new NotFoundObjectResult(new { ErrorMessage = "No se ha encontrado la sala" });

            var pomodoro = room.Pomodoro;

            if (pomodoro == null) return new NotFoundObjectResult(new { ErrorMessage = "No se ha encontrado el pomodoro" });

            pomodoro.IsStudyTime = request.IsStudyTime;
            pomodoro.StartTime = request.StartTime;

            var result = _mapper.Map<UpdateRoomTimerPomodoroDto>(pomodoro);

            return new OkObjectResult(result);
        }
    }
}
