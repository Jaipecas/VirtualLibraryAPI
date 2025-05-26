
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.BoardFeatures.Queries.GetAllBoardsFeature;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetAllBoardsFeature : IRequestHandler<GetAllBoardsQuery, Result<List<GetAllBoardsDto>>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBoardsFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllBoardsDto>>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId!);

            if (user == null) return Result<List<GetAllBoardsDto>>.Failure($"El usuario con id {request.UserId} no existe");

            var boards = await _unitOfWork.Boards.GetAllUserBoards(request.UserId!);

            if (boards.Count == 0) return Result<List<GetAllBoardsDto>>.Success([]);

            var result = _mapper.Map<List<GetAllBoardsDto>>(boards);

            return Result<List<GetAllBoardsDto>>.Success(result);
        }
    }
}
