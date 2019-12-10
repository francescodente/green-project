namespace FruitRacers.Backend.Core.Entities.Abstractions
{
    public abstract class AbstractRole
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
