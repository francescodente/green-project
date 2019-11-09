namespace FruitRacers.Backend.Core.Dto
{
    public class PasswordChangeRequestDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}