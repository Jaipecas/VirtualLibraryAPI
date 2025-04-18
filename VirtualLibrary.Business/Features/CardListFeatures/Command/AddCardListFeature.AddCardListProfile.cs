
using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class AddCardListFeature
    {
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
