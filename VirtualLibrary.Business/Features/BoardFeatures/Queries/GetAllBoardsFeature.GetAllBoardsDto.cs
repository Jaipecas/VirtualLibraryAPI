namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetAllBoardsFeature
    {
        public class GetAllBoardsDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
        }
    }
}
