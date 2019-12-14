namespace FruitRacers.Backend.Core.Entities
{
    public abstract class Role
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
