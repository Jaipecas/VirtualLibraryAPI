
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.UserFeatures.Queries.GetUserDataByIdFeature;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature : IRequestHandler<GetUserDataByIdQuery, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDataByIdFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetUserDataByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId);

            if (user == null) return new NotFoundObjectResult(new { errorMessage = "No se ha encontrado el usuario" });

            var result = _mapper.Map<GetUserDataByIdDto>(user);

            return new OkObjectResult(result);
        }
    }
}
