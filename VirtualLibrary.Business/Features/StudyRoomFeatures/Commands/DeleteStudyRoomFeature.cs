using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.DeleteStudyRoomFeature;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class DeleteStudyRoomFeature : IRequestHandler<DeleteStudyRoomCommand, Result<bool>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;

        public DeleteStudyRoomFeature(IVirtualLibraryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteStudyRoomCommand request, CancellationToken cancellationToken)
        {
            var studyRoom = await _unitOfWork.StudyRooms.GetById(request.StudyRoomId);

            if (studyRoom == null) return Result<bool>.Failure("No se ha encontrado sala de estudio");

            studyRoom.StudyRoomUsers?.ForEach(async ru => await _unitOfWork.StudyRoomUser.Delete(ru.Id));           

            await _unitOfWork.StudyRooms.Delete(studyRoom.Id);

            await _unitOfWork.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
