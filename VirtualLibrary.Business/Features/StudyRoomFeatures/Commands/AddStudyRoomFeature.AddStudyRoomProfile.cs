using AutoMapper;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomsByOwnerFeature;


namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public partial class AddStudyRoomProfile : Profile
        {
            public AddStudyRoomProfile()
            {
                CreateMap<AddStudyRoomCommand, StudyRoom>()
                    .ForMember(x => x.Pomodoro, y => y.MapFrom(x => x.Pomodoro))
                    .ForMember(x => x.RoomNotifications, y => y.MapFrom(x => x.Notifications));

                CreateMap<PomodoroCommand, Pomodoro>();

                CreateMap<AddStudyRoomNotification, RoomNotification>();

                CreateMap<StudyRoom, AddStudyRoomDto>()
                  .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.StudyRoomUsers.Select(s => s.User).ToList()));

                CreateMap<Pomodoro, AddStudyRoomPomodoroDto>();

                CreateMap<User, AddStudyRoomUserDto>();

            }
        }
    }
}
