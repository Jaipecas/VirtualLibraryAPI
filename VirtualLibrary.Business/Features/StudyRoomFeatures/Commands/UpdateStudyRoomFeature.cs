using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature : IRequestHandler<UpdateStudyRoomCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Handle(UpdateStudyRoomCommand request, CancellationToken cancellationToken)
        {
            var studyRoom = await _unitOfWork.StudyRooms.GetById(request.Id);

            if (studyRoom == null) return new NotFoundObjectResult(new { errorMessage = "No se ha encontrado la sala" });

            _mapper.Map(request, studyRoom);

            var users = await _unitOfWork.Users.GetUsersAsync(request.UsersIds);

            if (users == null || users.Count == 0) return new NotFoundObjectResult(new { errorMessage = "No se han encontrado los usuarios" });

            _unitOfWork.StudyRoomUser.RemoveRoomUsers(studyRoom.StudyRoomUsers);

            studyRoom.StudyRoomUsers = users
                                     .Select(user => new StudyRoomUser { User = user, StudyRoom = studyRoom })
                                     .ToList();

            await _unitOfWork.SaveChanges();

            return new OkObjectResult(true);
        }
    }
}
