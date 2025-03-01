
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoomUser(StudyRoom studyRoom, User user) : GenericEntity
    {
        public StudyRoom StudyRoom { get; set; } = studyRoom;
        public User User { get; set; } = user;
    }
}
