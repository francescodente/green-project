namespace GreenProject.Backend.Core.Utils.PasswordHashing
{
    public interface IHashCalculator
    {
        byte[] Hash(string password, byte[] salt, int length);
    }
}
