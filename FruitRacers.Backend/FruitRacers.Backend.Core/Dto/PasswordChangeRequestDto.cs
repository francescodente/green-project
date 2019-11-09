namespace FruitRacers.Backend.Core.Services.Authentication
{
    public class PasswordChangeRequestDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}