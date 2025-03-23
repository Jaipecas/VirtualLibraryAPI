
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
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

            var recipient = await _unitOfWork.Users.FindByIdAsync(request.RecipientId);

            if (recipient == null) return new NotFoundObjectResult(new { ErrorMessage = "Receptor no existe" });

            var notification = _mapper.Map<Notification>(request);

            await _unitOfWork.Notifications.Add(notification);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddNotificationDto>(notification);

            return new OkObjectResult(result);
        }
    }
}
