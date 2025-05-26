
using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature
    {
        public class UpdateRoomTimerProfile : Profile
        {
            public UpdateRoomTimerProfile()
            {
                CreateMap<Pomodoro, UpdateRoomTimerPomodoroDto>();
            }
        }
    }
}
