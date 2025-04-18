
using AutoMapper;
using FluentValidation;
using MediatR;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain.BoardEntities;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.CardListFeatures.Command.AddCardListFeature;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public class AddCardListFeature : IRequestHandler<AddCardListCommand, Result<AddCardListDto>>
    {
        private readonly IVirtualLibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCardListFeature(IVirtualLibraryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<AddCardListDto>> Handle(AddCardListCommand request, CancellationToken cancellationToken)
        {
            var cardList = _mapper.Map<CardList>(request);

            await _unitOfWork.CardLists.Add(cardList);

            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<AddCardListDto>(cardList);

            return Result<AddCardListDto>.Success(result);
        }

        public class AddCardListCommand : IRequest<Result<AddCardListDto>>
        {
            public int BoardId { get; set; }
            public string? Title { get; set; }
        }

        public class AddCardListDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
            public required int BoardId { get; set; }
        }

        public class AddCardListValidations : AbstractValidator<AddCardListCommand>
        {
            public AddCardListValidations()
            {
                {
                    RuleFor(r => r.BoardId).NotEmpty().GreaterThan(0);
                    RuleFor(r => r.Title).NotEmpty();
                }
            }
        }

        public class AddCardListProfile : Profile
        {
            public AddCardListProfile()
            {
                CreateMap<AddCardListCommand, CardList>();
                CreateMap<CardList, AddCardListDto>();
            }
        }
    }
}
