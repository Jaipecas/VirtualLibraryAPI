
using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetBoardByIdFeature
    {
        public class GetBoardByIdProfile : Profile
        {
            public GetBoardByIdProfile()
            {
                CreateMap<Board, GetBoardByIdDto>()
                     .ForMember(dest => dest.CardLists, opt => opt.MapFrom(src => src.CardLists));

                CreateMap<CardList, GetBoardByIdCardListDto>()
                    .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.Cards!.OrderBy(c => c.Order))); 

                CreateMap<Card, GetBoardByIdCardDto>();
            }
        }

    }
}

