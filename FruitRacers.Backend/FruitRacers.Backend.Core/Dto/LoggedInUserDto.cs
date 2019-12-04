namespace FruitRacers.Backend.Core.Dto
{
    public class LoggedInUserDto : UserDto
    {
        public bool IsAdmin { get; set; }
        public bool IsDeliveryCompany { get; set; }
    }
}
