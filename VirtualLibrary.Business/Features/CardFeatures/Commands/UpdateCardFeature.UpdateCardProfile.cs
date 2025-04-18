using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class UpdateCardFeature
    {
        public class UpdateCardProfile : Profile
        {
            public UpdateCardProfile()
            {
                CreateMap<UpdateCardCommand, Card>();
                CreateMap<Card, UpdateCardDto>();
            }
        }
    }
}
