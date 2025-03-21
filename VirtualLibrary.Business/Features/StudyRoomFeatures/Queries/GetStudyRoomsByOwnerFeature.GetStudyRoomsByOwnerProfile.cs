using AutoMapper;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature
    {
        public class GetStudyRoomsByOwnerProfile : Profile
        {
            public GetStudyRoomsByOwnerProfile()
            {
                CreateMap<StudyRoom, StudyRoomDto>()
                    .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.StudyRoomUsers.Select(s => s.User).ToList()));

                CreateMap<Pomodoro, PomodoroDto>();

                CreateMap<User, UserDto>();
            }
        }
    }
}
