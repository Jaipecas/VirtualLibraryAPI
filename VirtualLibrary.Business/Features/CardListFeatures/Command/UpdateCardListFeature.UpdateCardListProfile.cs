using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class UpdateCardListFeature
    {
        public class UpdateCardListProfile : Profile
        {
            public UpdateCardListProfile()
            {
                CreateMap<UpdateCardListCommand, CardList>();
                CreateMap<CardList, UpdateCardListDto>();
            }
        }
    }
}
