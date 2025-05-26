namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpDto
        {
            public required string Id { get; set; }
            public required string Email { get; set; }
            public required string UserName { get; set; }
            public required string Logo { get; set; }
        }
    }

}
