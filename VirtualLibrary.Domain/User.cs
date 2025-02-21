
using Microsoft.AspNetCore.Identity;

namespace VirtualLibrary.Domain
{
    public class User : IdentityUser
    {
        public string? Logo { get; set; }
    }
}
