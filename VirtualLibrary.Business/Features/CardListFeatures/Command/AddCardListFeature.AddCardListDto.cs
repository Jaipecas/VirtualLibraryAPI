namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class AddCardListFeature
    {
        public class AddCardListDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
            public required int BoardId { get; set; }
        }
    }
}
