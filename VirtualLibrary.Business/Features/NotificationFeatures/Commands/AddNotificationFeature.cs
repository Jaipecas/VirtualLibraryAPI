
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using VirtualLibrary.Domain.Constants;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.NotificationFeatures.AddNotificationFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature : IRequestHandler<AddNotificationCommand, Result<AddNotificationDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddNotificationFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<AddNotificationDto>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var sender = await _unitOfWork.Users.FindByIdAsync(request.SenderId);

            if (sender == null) return Result<AddNotificationDto>.Failure("Emisario no existe");

            if (sender.UserName == request.RecipientName) return Result<AddNotificationDto>.Failure("No puedes enviarte notificaciones a ti mismo");

            var recipient = await _unitOfWork.Users.FindByNameAsync(request.RecipientName);

            if (recipient == null) return Result<AddNotificationDto>.Failure("Receptor no existe");

            Notification notification;

            switch (request.NotificationType)
            {
                case NotificationTypes.RoomNotification:
                    notification = _mapper.Map<RoomNotification>(request);
                    break;
                case NotificationTypes.FriendNotification:

                    notification = _mapper.Map<FriendNotification>(request);

                    var isFriend = sender.UserFriends.Any(friend => friend.FriendId == recipient.Id);

                    if (isFriend) return Result<AddNotificationDto>.Failure("Ya tienes agregado como amigos a este usuario");

                    notification.RecipientId = recipient.Id;
                    break;
                default:
                    return Result<AddNotificationDto>.Failure("EL tipo de notificación indicado no existe");
            }

            await _unitOfWork.Notifications.Add(notification);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddNotificationDto>(notification);

            return Result<AddNotificationDto>.Success(result);
        }
    }
}
