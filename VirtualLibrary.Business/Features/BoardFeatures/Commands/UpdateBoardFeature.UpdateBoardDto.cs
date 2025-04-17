namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class UpdateBoardFeature
    {
        public class UpdateBoardDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
        }
    }
}
