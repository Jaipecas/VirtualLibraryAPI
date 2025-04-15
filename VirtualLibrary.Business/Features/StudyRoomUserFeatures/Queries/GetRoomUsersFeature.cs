
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries.GetRoomUsersFeature;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature : IRequestHandler<GetRoomUsersQuery, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoomUsersFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Handle(GetRoomUsersQuery request, CancellationToken cancellationToken)
        {
            var roomUsers = await _unitOfWork.StudyRoomUser.GetByRoomId(request.RoomId);

            GetRoomUsersDto? result = null;

            if (roomUsers!.Count != 0)
            {
                roomUsers = roomUsers.Where(ru => ru.IsConnected == request.IsConnected).ToList();

                result = _mapper.Map<GetRoomUsersDto>(roomUsers);

                return new OkObjectResult(result);
            }

            return new OkObjectResult(result);
        }
    }
}
