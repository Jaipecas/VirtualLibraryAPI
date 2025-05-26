using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class LogoutFeature
    {
        public class LogoutCommand : IRequest<Result<LogoutDto>>
        {
        }
    }
}
