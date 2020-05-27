namespace GreenProject.Backend.Core.Utils.PasswordHashing
{
    public interface IStringEncoding
    {
        string BytesToString(byte[] bytes);

        byte[] StringToBytes(string message);
    }
}
