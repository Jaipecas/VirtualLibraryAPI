
using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature
    {
        public class GetStudyRoomByIdProfile : Profile
        {
            public GetStudyRoomByIdProfile()
            {
                CreateMap<StudyRoom, GetStudyRoomByIdDto>()
                    .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.StudyRoomUsers.Select(s => s.User).ToList()));

                CreateMap<Pomodoro, GetStudyRoomByIdPomodoroDto>();

                CreateMap<User, GetStudyRoomByIdUserDto>();
            }
        }
    }
}
