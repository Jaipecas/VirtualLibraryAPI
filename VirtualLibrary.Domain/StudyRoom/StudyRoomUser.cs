
namespace VirtualLibrary.Domain.StudyRoom
{
    public class StudyRoomUser : GenericEntity
    {
        public required StudyRoom StudyRoom { get; set; }
        public required User User { get; set; }
    }
}
