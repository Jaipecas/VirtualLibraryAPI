namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature
    {
        public class GetRoomUsersDto
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public string? Logo { get; set; }
        }
    }
}
