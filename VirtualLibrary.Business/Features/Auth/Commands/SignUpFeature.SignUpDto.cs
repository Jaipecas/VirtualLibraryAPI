namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpDto
        {
            public required string Token { get; set; }
            public required string Email { get; set; }
            public required string UserName { get; set; }
        }
    }

}
