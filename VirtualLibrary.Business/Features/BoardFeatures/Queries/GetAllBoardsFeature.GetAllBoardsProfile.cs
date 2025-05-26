
using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetAllBoardsFeature
    {
        public class GetAllBoardsProfile : Profile
        {
            public GetAllBoardsProfile()
            {
                CreateMap<Board, GetAllBoardsDto>();
            }
        }
    }
}
