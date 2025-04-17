namespace VirtualLibrary.Application.Features.BoardFeatures
{
    public partial class AddBoardFeature
    {
        public class AddBoardDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
        }

    }
}
