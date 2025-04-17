
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.BoardFeatures.Queries.GetBoardByIdFeature;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetBoardByIdFeature : IRequestHandler<GetBoardByIdQuery, Result<GetBoardByIdDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardByIdFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetBoardByIdDto>> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _unitOfWork.Boards.GetById(request.Id);

            if (board == null) return Result<GetBoardByIdDto>.Failure($"El board con id {request.Id} no existe");

            var result = _mapper.Map<GetBoardByIdDto>(board);

            return Result<GetBoardByIdDto>.Success(result);
        }
    }
}

