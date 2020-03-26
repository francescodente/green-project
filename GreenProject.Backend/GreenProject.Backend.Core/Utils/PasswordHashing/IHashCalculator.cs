namespace GreenProject.Backend.Core.Utils
{
    public interface IHashCalculator
    {
        byte[] Hash(string password, byte[] salt, int length);
    }
}
