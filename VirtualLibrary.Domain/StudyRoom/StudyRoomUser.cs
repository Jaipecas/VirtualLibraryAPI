
namespace VirtualLibrary.Domain.StudyRoom
{
    public class StudyRoomUser
    {
        public required StudyRoom StudyRoom { get; set; }
        public required User User { get; set; }
    }
}
