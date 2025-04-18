namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class UpdateCardListFeature
    {
        public class UpdateCardListDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
        }
    }
}
