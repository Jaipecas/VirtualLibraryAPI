
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands.UpdateStudyRoomUserFeature;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature : IRequestHandler<UpdateStudyRoomUserCommand, Result<UpdateStudyRoomUserDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudyRoomUserFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<UpdateStudyRoomUserDto>> Handle(UpdateStudyRoomUserCommand request, CancellationToken cancellationToken)
        {
            var roomUsers = await _unitOfWork.StudyRoomUser.GetByRoomId(request.RoomId);

            if (roomUsers == null) return Result<UpdateStudyRoomUserDto>.Failure("No existen usuarios en esta sala");

            var roomUser = roomUsers.FirstOrDefault(ru => ru.UserId == request.UserId);

            if (roomUser == null) return Result<UpdateStudyRoomUserDto>.Failure("El usuario no se encuentra en la sala");

            roomUser.IsConnected = request.IsConnected;

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateStudyRoomUserDto>(roomUser);

            return Result<UpdateStudyRoomUserDto>.Success(result);
        }
    }
}

