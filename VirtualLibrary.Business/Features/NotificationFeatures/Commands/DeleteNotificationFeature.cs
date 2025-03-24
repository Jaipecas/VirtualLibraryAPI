
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Constants;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.NotificationFeatures.DeleteNotificationFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature : IRequestHandler<DeleteNotificationCommand, IActionResult>
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

        public async Task<IActionResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _unitOfWork.Notifications.GetById(request.Id);

            if (notification == null) return new NotFoundObjectResult(new { ErrorMessage = "No se encuentra la notificación" });

            if (request.IsAccepted)
            {
                switch (request.NotificationType)
                {
                    case NotificationTypes.RoomNotification:

                        var roomNotification = _mapper.Map<RoomNotification>(notification);

                        var room = await _unitOfWork.StudyRooms.GetById(roomNotification.RoomId);

                        if (room == null) return new NotFoundObjectResult(new { ErrorMessage = "No la sala de estudio" });

                        var user = room.StudyRoomUsers.Find(roomUser => roomUser.User.Id == roomNotification.RecipientId);

                        if (user == null) return new NotFoundObjectResult(new { ErrorMessage = "No se encuentra el usuario" });

                        user.IsAccepted = true;

                        await _unitOfWork.SaveChanges();

                        break;
                    default:
                        return new BadRequestObjectResult(new { ErrorMessage = "EL tipo de notificación indicado no existe" });
                }
            }

            await _unitOfWork.Notifications.Delete(notification.Id);

            await _unitOfWork.SaveChanges();

            return new OkObjectResult(true);
        }
    }
}
