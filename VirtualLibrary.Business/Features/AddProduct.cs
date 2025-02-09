using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features
{
    public class AddProductRequest : IRequest<Unit>
    {
        public required string Name { get; set; }

    }
    public class AddProductRequestValidation : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidation()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }

    public class AddProductHandle : IRequestHandler<AddProductRequest, Unit>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOFwork;

        public AddProductHandle(IVirtualLibraryUnitOfWork unitOFwork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOFwork = unitOFwork;
        }

        public async Task<Unit> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new() { Name = request.Name };

            await _unitOFwork.Products.Add(product);

            var response = await _unitOFwork.Save();

            return response > 0 ? Unit.Value : throw new Exception("No se insertó el Product");
        }
    }
}
