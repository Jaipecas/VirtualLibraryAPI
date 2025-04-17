
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.BoardFeatures.Commands.UpdateBoardFeature;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class UpdateBoardFeature : IRequestHandler<UpdateBoardCommand, Result<UpdateBoardDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBoardFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<UpdateBoardDto>> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _unitOfWork.Boards.GetById(request.Id);

            if (board == null) return Result<UpdateBoardDto>.Failure("El board no existe");

            board.Title = request.Title!;

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<UpdateBoardDto>(board);            

            return Result<UpdateBoardDto>.Success(result);
        }
    }
}
