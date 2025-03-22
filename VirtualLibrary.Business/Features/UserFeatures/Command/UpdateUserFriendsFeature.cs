
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.UserEntities;
using static VirtualLibrary.Application.Features.UserFeatures.Command.UpdateUserFriendsFeature;

namespace VirtualLibrary.Application.Features.UserFeatures.Command
{
    public partial class UpdateUserFriendsFeature : IRequestHandler<UpdateUserFriendsCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserFriendsFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UpdateUserFriendsCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId);

            if (user == null) return new NotFoundObjectResult(new { errorMessage = "No se ha encontrado el usuario" });

            var friend = await _unitOfWork.Users.FindByIdAsync(request.FriendId);

            if (friend == null) return new NotFoundObjectResult(new { errorMessage = "No se ha encontrado el amigo" });

            var friendExist = user.UserFriends.Select(userFriend => userFriend.Friend).Any(f => f.Id == friend.Id);

            if (friendExist) return new BadRequestObjectResult(new { errorMessage = "Ya tienes agregado este amigo" });

            user.UserFriends.Add(new UserFriend { UserId = user.Id, User = user, Friend = friend, FriendId = friend.Id });

            await _unitOfWork.SaveChanges();

            return new OkObjectResult(true);
        }
    }
}
