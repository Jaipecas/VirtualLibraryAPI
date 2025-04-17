
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
                CreateMap<Board, GetBoardByIdDto>();
            }
        }

    }
}

