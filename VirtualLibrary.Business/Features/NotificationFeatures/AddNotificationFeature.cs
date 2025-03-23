
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.NotificationFeatures.AddNotificationFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public class AddNotificationFeature : IRequestHandler<AddNotificationCommand, IActionResult>
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

        public class AddNotificationCommand : IRequest<IActionResult>
        {
            public required string SenderId { get; set; }
            public required string RecipientId { get; set; }
            public required string Title { get; set; }
            public required string Message { get; set; }
        }

        public class AddNotificationValidations : AbstractValidator<AddNotificationCommand>
        {
            public AddNotificationValidations()
            {

                RuleFor(r => r.SenderId).NotEmpty();
                RuleFor(r => r.RecipientId).NotEmpty();
                RuleFor(r => r.Title).NotEmpty();
                RuleFor(r => r.Message).NotEmpty();
            }
        }


        public class AddNotificationProfile : Profile
        {
            public AddNotificationProfile()
            {
                CreateMap<AddNotificationCommand, Notification>();
                CreateMap<Notification, AddNotificationDto>();
            }
        }

        public class AddNotificationDto
        {
            public required int Id { get; set; }
            public required string SenderId { get; set; }
            public required string RecipientId { get; set; }
            public required string Title { get; set; }
            public required string Message { get; set; }
        }

    }
}
