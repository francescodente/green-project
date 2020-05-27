namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public static class CompatibilityDto
    {
        public class OutputWithProduct
        {
            public ProductDto.Output Product { get; set; }
            public int? Maximum { get; set; }
        }

        public class OutputWithCrate
        {
            public int CrateId { get; set; }
            public int? Maximum { get; set; }
        }

        public class InputWithCrate
        {
            public int CrateId { get; set; }
            public int? Maximum { get; set; }
        }
    }
}
