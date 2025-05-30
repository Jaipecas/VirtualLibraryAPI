﻿
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.BoardFeatures.Commands.DeleteBoardFeature;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class DeleteBoardFeature : IRequestHandler<DeleteBoardCommand, Result<bool>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBoardFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _unitOfWork.Boards.GetById(request.Id);

            if (board == null) return Result<bool>.Failure($"No existe un board con id: {request.Id}");

            await _unitOfWork.Boards.Delete(board!.Id);

            await _unitOfWork.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
