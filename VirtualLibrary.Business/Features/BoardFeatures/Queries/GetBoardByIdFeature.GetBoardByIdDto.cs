namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetBoardByIdFeature
    {
        public class GetBoardByIdDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
        }

    }
}

