namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class UpdateCardFeature
    {
        public class UpdateCardDto
        {
            public required int Id { get; set; }
            public required int CardListId { get; set; }
            public required string Title { get; set; }
        }
    }
}
