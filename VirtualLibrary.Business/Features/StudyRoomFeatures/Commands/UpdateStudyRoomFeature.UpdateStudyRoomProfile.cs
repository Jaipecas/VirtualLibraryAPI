using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature
    {
        public class UpdateStudyRoomProfile : Profile
        {
            public UpdateStudyRoomProfile()
            {
                CreateMap<UpdateStudyRoomCommand, StudyRoom>();
                CreateMap<PomodoroUpdateCommand, Pomodoro>();
            }
        }


    }
}
