using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class LogoutFeature
    {
        public class LogoutCommand : IRequest<IActionResult>
        {
        }
    }
}
