using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using VirtualLibrary.Domain.Constants;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature : IRequestHandler<UpdateStudyRoomCommand, Result<UpdateStudyRoomDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<UpdateStudyRoomDto>> Handle(UpdateStudyRoomCommand request, CancellationToken cancellationToken)
        {
            var studyRoom = await _unitOfWork.StudyRooms.GetById((int)request.Id!);

            if (studyRoom == null) return Result<UpdateStudyRoomDto>.Failure("No se ha encontrado la sala");

            _mapper.Map(request, studyRoom);

            if (request.UsersIds?.Count > 0)
            {
                var users = await _unitOfWork.Users.GetUsersAsync(request.UsersIds);

                if (users == null) return Result<UpdateStudyRoomDto>.Failure("No se han encontrado los usuarios");

                var roomUsersIds = studyRoom?.StudyRoomUsers?.Select(su => su.UserId).ToList();

                var newUsers = users.Where(user => !roomUsersIds.Contains(user.Id)).ToList();

                var notifications = newUsers.Select(user => new RoomNotification
                {
                    SenderId = studyRoom!.OwnerId,
                    RecipientId = user.Id,
                    Title = $"Invitación Sala: {studyRoom.Name}",
                    Message = $"{studyRoom.Description}",
                    RoomId = studyRoom.Id,
                    NotificationType = NotificationTypes.RoomNotification
                }).ToList();

                notifications.ForEach(async notification => await _unitOfWork.Notifications.Add(notification));

                newUsers.ForEach(async user => await _unitOfWork.StudyRoomUser.Add(new StudyRoomUser { UserId = user.Id, StudyRoomId = studyRoom.Id }));
            }

            if (request?.UsersIds?.Count == 0)
            {
                var removeUsers = studyRoom!.StudyRoomUsers!.Where(ru => ru.UserId != studyRoom.OwnerId).ToList();
                _unitOfWork.StudyRoomUser.RemoveRoomUsers(removeUsers);
            }

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateStudyRoomDto>(studyRoom);

            return Result<UpdateStudyRoomDto>.Success(result);
        }

    }
}
