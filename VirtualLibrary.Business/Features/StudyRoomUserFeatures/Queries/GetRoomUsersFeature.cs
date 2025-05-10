
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries.GetRoomUsersFeature;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature : IRequestHandler<GetRoomUsersQuery, Result<List<GetRoomUsersDto>>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoomUsersFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<List<GetRoomUsersDto>>> Handle(GetRoomUsersQuery request, CancellationToken cancellationToken)
        {
            var roomUsers = await _unitOfWork.StudyRoomUser.GetByRoomId(request.RoomId);

            List<GetRoomUsersDto>? result = null;

            if (roomUsers!.Count != 0)
            {
                roomUsers = roomUsers.Where(ru => ru.IsConnected == request.IsConnected).ToList();

                var users = roomUsers.Select(ru => ru.User).ToList();
                result = _mapper.Map<List<GetRoomUsersDto>>(users);

                return Result<List<GetRoomUsersDto>>.Success(result);
            }

            return Result<List<GetRoomUsersDto>>.Success(result);
        }
    }
}
