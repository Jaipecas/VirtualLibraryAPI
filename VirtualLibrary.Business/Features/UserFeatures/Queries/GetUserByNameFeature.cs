
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using static VirtualLibrary.Application.Features.UserFeatures.Queries.GetUserByNameFeature;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserByNameFeature : IRequestHandler<GetUserByNameQuery, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByNameFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByNameAsync(request.UserName);

            if (user == null) return new NotFoundObjectResult(new { errorMessage = "No se ha encontrado el usuario" });

            var result = _mapper.Map<GetUserByNameDto>(user);

            return new OkObjectResult(result);
        }
    }
}
