
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateRoomTimerFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature : IRequestHandler<UpdateRoomTimerCommand, Result<UpdateRoomTimerPomodoroDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoomTimerFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UpdateRoomTimerPomodoroDto>> Handle(UpdateRoomTimerCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.StudyRooms.GetById(request.RoomId);

            if (room == null) return Result<UpdateRoomTimerPomodoroDto>.Failure("No se ha encontrado la sala");

            var pomodoro = room.Pomodoro;

            if (pomodoro == null) return Result<UpdateRoomTimerPomodoroDto>.Failure("No se ha encontrado el pomodoro");

            pomodoro.IsStudyTime = request.IsStudyTime;
            pomodoro.EndTime = DateTime.Now.AddMinutes(request.IsStudyTime ? pomodoro.PomodoroTime : pomodoro.BreakTime);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateRoomTimerPomodoroDto>(pomodoro);

            return Result<UpdateRoomTimerPomodoroDto>.Success(result);
        }
    }
}
