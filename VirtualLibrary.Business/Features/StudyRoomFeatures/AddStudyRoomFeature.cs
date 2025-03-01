using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.AddStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures
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
            var users = await _unitOfWork.Users.GetUsersAsync(request.UsersIds);

            if (users == null) return new BadRequestObjectResult(new { errorMessage =  "Not found users"});

            var studyRoom = _mapper.Map<StudyRoom>(request);

            studyRoom.StudyRoomUsers = users.Select(user => new StudyRoomUser(studyRoom!, user)).ToList();

            await _unitOfWork.StudyRooms.Add(studyRoom);

            await _unitOfWork.SaveChanges();

            return new OkObjectResult(true);
        }
    }
}
