namespace Shared.Models.Sender
{
    public record Order
    {
        public string Id { get; init; }
        public decimal Price { get; init; }
        public string ProductName { get; init; }

        public List<OrderLine> OrderLines { get; init; } = [];
    }

    public record OrderLine
    {
        public string Reference { get; init; }
        public decimal ItemPrice { get; init; }
        public bool TaxReturn { get; init; }
    }
}
