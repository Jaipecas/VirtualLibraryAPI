using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature : IRequestHandler<UpdateStudyRoomCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Handle(UpdateStudyRoomCommand request, CancellationToken cancellationToken)
        {
            //TODO terminar handler
            var studyRoom = await _unitOfWork.StudyRooms.GetById(request.Id);

            if (studyRoom == null) return new NotFoundObjectResult(new { errorMessage = "No se ha encontrado la sala" });

            return new OkObjectResult(true);


        }
    }
}
