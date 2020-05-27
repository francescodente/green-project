namespace GreenProject.Backend.Contracts.Authentication
{
    public class PasswordRecoveryChangeDto
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
