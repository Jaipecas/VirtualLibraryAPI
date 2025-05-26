namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature
    {
        public class GetUserDataByIdDto
        {
            public required string Id { get; set; }
            public string? Logo { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public List<GetUserDataByIdFriendDto>? Friends { get; set; }
        }

        public class GetUserDataByIdFriendDto
        {
            public required string Id { get; set; }
            public string? Logo { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }
    }
}
