using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;


namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public partial class AddStudyRoomProfile : Profile
        {
            public AddStudyRoomProfile()
            {
                CreateMap<AddStudyRoomCommand, StudyRoom>().ForMember(x => x.Pomodoro, y => y.MapFrom(x => x.Pomodoro));
                CreateMap<PomodoroCommand, Pomodoro>();
            }
        }
    }
}
