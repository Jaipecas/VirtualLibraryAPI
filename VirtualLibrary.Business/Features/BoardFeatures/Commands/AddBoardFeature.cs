
using AutoMapper;
using MediatR;
using VirtualLibrary.Domain.Common;
using VirtualLibrary.Domain.BoardEntities;
using static VirtualLibrary.Application.Features.BoardFeatures.AddBoardFeature;
using VirtualLibrary.Application.Persistence;

namespace VirtualLibrary.Application.Features.BoardFeatures
{
    public partial class AddBoardFeature : IRequestHandler<AddBoardCommand, Result<AddBoardDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<AddBoardDto>> Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var board = _mapper.Map<Board>(request);

            await _unitOfWork.Boards.Add(board);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddBoardDto>(board);

            return Result<AddBoardDto>.Success(result);
        }
    }
}
