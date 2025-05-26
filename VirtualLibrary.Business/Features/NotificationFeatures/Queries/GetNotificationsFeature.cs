
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.NotificationFeatures.Queries.GetNotificationsFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature : IRequestHandler<GetNoticationsQuery, Result<List<NotificationDto>>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNotificationsFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<List<NotificationDto>>> Handle(GetNoticationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _unitOfWork.Notifications.GetNotifications(request.UserId);

            var result = _mapper.Map<List<NotificationDto>>(notifications);

            return Result<List<NotificationDto>>.Success(result);
        }
    }
}
