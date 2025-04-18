using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class AddCardFeature
    {
        public class AddCardProfile : Profile
        {
            public AddCardProfile()
            {
                CreateMap<AddCardCommand, Card>();
                CreateMap<Card, AddCardDto>();
            }
        }
    }
}
