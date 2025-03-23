
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class RoomNotification : Notification
    {
        public required int RoomId { get; set; }
        public required StudyRoom StudyRoom { get; set; }
    }
}
