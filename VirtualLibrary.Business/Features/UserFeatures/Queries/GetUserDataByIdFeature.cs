
using AutoMapper;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.UserFeatures.Queries.GetUserDataByIdFeature;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature : IRequestHandler<GetUserDataByIdQuery, Result<GetUserDataByIdDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDataByIdFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetUserDataByIdDto>> Handle(GetUserDataByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId);

            if (user == null) return Result<GetUserDataByIdDto>.Failure("No se ha encontrado el usuario");

            var result = _mapper.Map<GetUserDataByIdDto>(user);

            return Result<GetUserDataByIdDto>.Success(result);
        }
    }
}
