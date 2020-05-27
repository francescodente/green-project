using GreenProject.Backend.Entities.Utils;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public static class CrateDto
    {
        public class Output
        {
            public int CrateId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Money Price { get; set; }
            public decimal IvaPercentage { get; set; }
            public int Capacity { get; set; }
            public string ImageUrl { get; set; }
            public bool IsStarred { get; set; }
            public int CategoryId { get; set; }
        }

        public class Input
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Money Price { get; set; }
            public decimal IvaPercentage { get; set; }
            public int Capacity { get; set; }
            public bool IsStarred { get; set; }
        }
    }
}
