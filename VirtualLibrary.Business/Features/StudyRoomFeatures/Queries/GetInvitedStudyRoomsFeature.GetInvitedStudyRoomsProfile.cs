
using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetInvitedStudyRoomsFeature
    {
        public class GetInvitedStudyRoomsProfile : Profile
        {
            public GetInvitedStudyRoomsProfile()
            {
                CreateMap<StudyRoom, GetInvitedStudyRoomsDto>()
                    .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.StudyRoomUsers.Select(s => s.User).ToList()));

                CreateMap<Pomodoro, GetInvitedStudyRoomsPomodoroDto>();

                CreateMap<User, GetInvitedStudyRoomsUserDto>();
            }
        }
    }
}
