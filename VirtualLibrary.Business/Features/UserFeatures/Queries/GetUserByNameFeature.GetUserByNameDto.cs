namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserByNameFeature
    {
        public class GetUserByNameDto
        {
            public required string Id { get; set; }
            public string? Logo { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public List<GetUserByNameFriendDto>? Friends { get; set; }
        }

        public class GetUserByNameFriendDto
        {
            public required string Id { get; set; }
            public string? Logo { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }
    }
}
