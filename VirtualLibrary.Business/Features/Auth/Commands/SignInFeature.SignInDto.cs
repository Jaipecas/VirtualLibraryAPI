namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInDto
        {
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public required string Token { get; set; }
        }
    }
}
