namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserByNameFeature
    {
        public class GetUserByNameDto
        {
            public string? Logo { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }
    }
}
