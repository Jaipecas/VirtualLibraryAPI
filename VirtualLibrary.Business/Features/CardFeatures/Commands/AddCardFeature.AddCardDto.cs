namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class AddCardFeature
    {
        public class AddCardDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
            public required int CardListId { get; set; }
        }
    }
}
