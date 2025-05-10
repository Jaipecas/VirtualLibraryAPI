using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature
    {
        public class GetUserDataByIdQuery : IRequest<Result<GetUserDataByIdDto>>
        {
            public required string UserId { get; set; }
        }
    }
}
