namespace GreenProject.Backend.Core.Utils.PasswordHashing
{
    public interface ISaltGenerator
    {
        byte[] NewSalt(int length);
    }
}
