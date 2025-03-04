using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.StudyRoomEntities;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.AddStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature : IRequestHandler<AddStudyRoomCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Handle(AddStudyRoomCommand request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetUsersAsync(request.UsersIds);

            if (users == null) return new BadRequestObjectResult(new { errorMessage =  "Not found users"});

            var owner = await _unitOfWork.Users.FindByIdAsync(request.OwnerId);

            if (owner == null) return new BadRequestObjectResult(new { errorMessage = "Not found owner" });

            var studyRoom = _mapper.Map<StudyRoom>(request);

            var httpContextUser = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            studyRoom.StudyRoomUsers = users.Select(user => new StudyRoomUser { StudyRoom = studyRoom, User = user, CreatedBy = httpContextUser!, CreatedDate = DateTime.Now}).ToList();
            
            studyRoom.Owner = owner;

            await _unitOfWork.StudyRooms.Add(studyRoom);

            await _unitOfWork.SaveChanges();

            return new OkObjectResult(true);
        }
    }
}
