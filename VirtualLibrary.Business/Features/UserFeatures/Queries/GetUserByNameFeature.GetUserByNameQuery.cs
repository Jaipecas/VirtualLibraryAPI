using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserByNameFeature
    {
        public class GetUserByNameQuery : IRequest<IActionResult>
        {
            public required string UserName { get; set; }
        }
    }
}
