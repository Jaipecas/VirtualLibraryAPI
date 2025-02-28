namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public class UpdateUserDto
        {
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }
    }
}
