
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Constants;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.NotificationFeatures.AddNotificationFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature : IRequestHandler<AddNotificationCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddNotificationFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var sender = await _unitOfWork.Users.FindByIdAsync(request.SenderId);

            if (sender == null) return new NotFoundObjectResult(new { ErrorMessage = "Emisario no existe" });

            var recipient = await _unitOfWork.Users.FindByNameAsync(request.RecipientName);

            if (recipient == null) return new NotFoundObjectResult(new { ErrorMessage = "Receptor no existe" });

            Notification notification;

            switch (request.NotificationType)
            {
                case NotificationTypes.RoomNotification:
                    notification = _mapper.Map<RoomNotification>(request);
                    break;
                case NotificationTypes.FriendNotification:
                    notification = _mapper.Map<FriendNotification>(request);
                    notification.RecipientId = recipient.Id;
                    break;
                default:
                    return new BadRequestObjectResult(new { ErrorMessage = "EL tipo de notificación indicado no existe" });
            }

            await _unitOfWork.Notifications.Add(notification);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddNotificationDto>(notification);

            return new OkObjectResult(result);
        }
    }
}
