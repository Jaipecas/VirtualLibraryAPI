
using AutoMapper;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserProfile : Profile
        {
            public UpdateStudyRoomUserProfile()
            {
                CreateMap<StudyRoomUser, UpdateStudyRoomUserDto>();
                CreateMap<UpdateStudyRoomUserDto, StudyRoomUser>();
            }
        }
    }
}

