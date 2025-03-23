
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.NotificationFeatures.DeleteNotificationFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature : IRequestHandler<DeleteNotificationCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteNotificationFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _unitOfWork.Notifications.GetById(request.Id);

            if (notification == null) return new NotFoundObjectResult(new { ErrorMessage = "No se encuentra la notificación" });

            if (request.IsAccepted)
            {

            }

            await _unitOfWork.Notifications.Delete(notification.Id);

            return new OkObjectResult(true);
        }
    }
}
