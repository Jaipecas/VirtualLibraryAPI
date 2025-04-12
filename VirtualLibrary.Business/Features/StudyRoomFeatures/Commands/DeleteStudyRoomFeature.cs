using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.DeleteStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class DeleteStudyRoomFeature : IRequestHandler<DeleteStudyRoomCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(DeleteStudyRoomCommand request, CancellationToken cancellationToken)
        {
            var studyRoom = await _unitOfWork.StudyRooms.GetById(request.StudyRoomId);

            if (studyRoom == null) return new NotFoundObjectResult(new { errorMessage = "No se ha enconntrado sala de estudio" });

            studyRoom.StudyRoomUsers?.ForEach(async ru => await _unitOfWork.StudyRoomUser.Delete(ru.Id));           

            await _unitOfWork.StudyRooms.Delete(studyRoom.Id);

            await _unitOfWork.SaveChanges();

            return new OkObjectResult(true);
        }
    }
}
