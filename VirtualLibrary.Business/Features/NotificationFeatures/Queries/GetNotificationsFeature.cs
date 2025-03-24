
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.NotificationFeatures.Queries.GetNotificationsFeature;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public class GetNotificationsFeature : IRequestHandler<GetNoticationsQuery, IActionResult>
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

        public class GetNoticationsQuery : IRequest<IActionResult>
        {
            public required string UserId { get; set; }
        }

        public class GetNotificationsValidations : AbstractValidator<GetNoticationsQuery>
        {
            public GetNotificationsValidations()
            {
                RuleFor(r => r.UserId).NotEmpty();
            }
        }

        public class GetNotificationsProfile : Profile
        {
            public GetNotificationsProfile()
            {
                CreateMap<Notification, NotificationDto>();
            }
        }

        public class NotificationDto
        {
            public required string Title { get; set; }
            public required string Message { get; set; }
            public required string NotificationType { get; set; }
        }


    }
}
