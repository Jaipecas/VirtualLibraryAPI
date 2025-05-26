
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using VirtualLibrary.Domain.Constants;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Domain.UserEntities;
using static VirtualLibrary.Application.Features.NotificationFeatures.DeleteNotificationFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature : IRequestHandler<DeleteNotificationCommand, Result<DeleteNotificationDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNotificationFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public class DeleteNotification : Profile
        {
            public DeleteNotification()
            {
                CreateMap<Notification, RoomNotification>()
                    .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => ((RoomNotification)src).RoomId));
            }
        }

        public async Task<Result<DeleteNotificationDto>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _unitOfWork.Notifications.GetById(request.Id);

            if (notification == null) return Result<DeleteNotificationDto>.Failure("No se encuentra la notificación");

            switch (request.NotificationType)
            {
                case NotificationTypes.RoomNotification:

                    var roomNotification = _mapper.Map<RoomNotification>(notification);

                    var room = await _unitOfWork.StudyRooms.GetById(roomNotification.RoomId);

                    var roomUser = room?.StudyRoomUsers.Find(ru => ru.UserId == roomNotification.RecipientId);

                    if (roomUser != null)
                    {
                        if (request.IsAccepted)
                        {
                            roomUser.IsAccepted = true;
                        }
                        else
                        {
                            await _unitOfWork.StudyRoomUser.Delete(roomUser.Id);
                        }
                    }
                    break;
                case NotificationTypes.FriendNotification:

                    if (request.IsAccepted)
                    {
                        await _unitOfWork.UserFriends.Add(new UserFriend { UserId = notification.SenderId, FriendId = notification.RecipientId });
                        await _unitOfWork.UserFriends.Add(new UserFriend { UserId = notification.RecipientId, FriendId = notification.SenderId });
                    }
                    break;
                default:
                    return Result<DeleteNotificationDto>.Failure("EL tipo de notificación indicado no existe");
            }

            await _unitOfWork.Notifications.Delete(notification.Id);

            await _unitOfWork.SaveChanges();

            return Result<DeleteNotificationDto>.Success(new DeleteNotificationDto { IsDeleted = true });
        }
    }
}
