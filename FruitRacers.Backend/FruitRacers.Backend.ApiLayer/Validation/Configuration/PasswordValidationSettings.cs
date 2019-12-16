namespace FruitRacers.Backend.ApiLayer.Validation.Configuration
{
    public class PasswordValidationSettings
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public string Regex { get; set; }
    }
}
