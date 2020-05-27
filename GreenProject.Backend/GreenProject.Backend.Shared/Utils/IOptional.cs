namespace GreenProject.Backend.Shared.Utils
{
    public interface IOptional<out T>
    {
        T Value { get; }

        bool IsPresent();

        bool IsAbsent();
    }
}
