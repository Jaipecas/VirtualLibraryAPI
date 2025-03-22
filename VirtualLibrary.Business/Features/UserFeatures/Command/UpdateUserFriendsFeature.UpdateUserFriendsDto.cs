namespace VirtualLibrary.Application.Features.UserFeatures.Command
{
    public partial class UpdateUserFriendsFeature
    {
        public class UpdateUserFriendsDto
        {
            public required string Id { get; set; }
            public string? Logo { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }
    }
}
