namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures
{
    public partial class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserDto
        {
            public required int Id { get; set; }
            public required int StudyRoomId { get; set; }
            public required string UserId { get; set; }
            public bool? IsAccepted { get; set; }
            public bool? IsConnected { get; set; }
        }
    }
}

