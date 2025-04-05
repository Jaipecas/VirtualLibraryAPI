
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class RoomNotification : Notification
    {
        public required int RoomId { get; set; }
        public StudyRoom? StudyRoom { get; set; }

        public RoomNotification() { }
    }
}
