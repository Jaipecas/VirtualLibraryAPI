using AutoMapper;
using VirtualLibrary.Domain;
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

                CreateMap<StudyRoom, UpdateStudyRoomDto>()
                  .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.StudyRoomUsers.Select(s => s.User).ToList()));

                CreateMap<Pomodoro, UpdateStudyRoomDtoPomodoroDto>();

                CreateMap<User, UpdateStudyRoomDtoUserDto>();
            }
        }
    }
}
