
using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.BoardFeatures
{
    public partial class AddBoardFeature
    {
        public class AddBoardProfile : Profile
        {
            public AddBoardProfile()
            {
                CreateMap<AddBoardCommand, Board>();
                CreateMap<Board, AddBoardDto>();
            }
        }

    }
}
