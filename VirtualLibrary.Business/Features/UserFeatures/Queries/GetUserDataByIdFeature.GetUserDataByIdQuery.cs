using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature
    {
        public class GetUserDataByIdQuery : IRequest<IActionResult>
        {
            public required string UserId { get; set; }
        }
    }
}
