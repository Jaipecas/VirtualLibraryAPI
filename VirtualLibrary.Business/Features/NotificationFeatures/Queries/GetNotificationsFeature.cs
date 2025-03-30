
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.NotificationFeatures.Queries.GetNotificationsFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature : IRequestHandler<GetNoticationsQuery, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNotificationsFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Handle(GetNoticationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _unitOfWork.Notifications.GetNotifications(request.UserId);

            var result = _mapper.Map<List<NotificationDto>>(notifications);

            return new OkObjectResult(result);
        }
    }
}
