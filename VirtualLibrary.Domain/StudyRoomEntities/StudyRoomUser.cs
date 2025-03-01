
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoomUser : GenericEntity
    {
        public required StudyRoom StudyRoom { get; set; }
        public required User User { get; set; } 
    }
}
