namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature
    {
        public class GetRoomUsersDto
        {
            public List<GetRoomUsersUserDto>? Users { get; set; }
        }

        public class GetRoomUsersUserDto
        {
            public required int Id { get; set; }
            public required string UserName { get; set; }
            public string? Logo { get; set; }
        }
    }
}
