
using AutoMapper;
using VirtualLibrary.Domain.BoardEntities;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class UpdateBoardFeature
    {
        public class UpdateBoardProfile : Profile
        {
            public UpdateBoardProfile()
            {
                CreateMap<UpdateBoardCommand, Board>();
                CreateMap<Board, UpdateBoardDto>();
            }
        }
    }
}
