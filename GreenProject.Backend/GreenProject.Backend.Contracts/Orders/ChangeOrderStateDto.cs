using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Contracts.Orders
{
    public class ChangeOrderStateDto
    {
        public OrderState NewState { get; set; }
    }
}
