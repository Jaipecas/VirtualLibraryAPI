using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Constants;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.AddStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature : IRequestHandler<AddStudyRoomCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(AddStudyRoomCommand request, CancellationToken cancellationToken)
        {
            var studyRoom = _mapper.Map<StudyRoom>(request);

            var owner = await _unitOfWork.Users.FindByIdAsync(request.OwnerId);

            if (owner == null) return new BadRequestObjectResult(new { errorMessage = "Not found owner" });

            studyRoom.Owner = owner;

            //añadimos tambien el owner como usuario de la sala
            studyRoom.StudyRoomUsers = new List<StudyRoomUser> { new() { StudyRoomId = studyRoom.Id, UserId = request.OwnerId } };

            if (request.UsersIds != null && request.UsersIds.Count != 0)
            {
                var users = await _unitOfWork.Users.GetUsersAsync(request.UsersIds);

                if (users == null || users.Count == 0) return new BadRequestObjectResult(new { errorMessage = "Not found users" });

                var newUsers = users.Select(user => new StudyRoomUser { StudyRoomId = studyRoom.Id, UserId = user.Id }).ToList();

                studyRoom.StudyRoomUsers.AddRange(newUsers);

                studyRoom.RoomNotifications = users.Select(user => new RoomNotification
                {
                    SenderId = owner.Id,
                    RecipientId = user.Id,
                    Title = $"Invitación Sala: {request.Name}",
                    Message = $"{request.Description}",
                    RoomId = studyRoom.Id,
                    NotificationType = NotificationTypes.RoomNotification
                }).ToList();
            }

            var roomCreated = await _unitOfWork.StudyRooms.Add(studyRoom);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddStudyRoomDto>(roomCreated);

            return new OkObjectResult(result);
        }
    }
}
