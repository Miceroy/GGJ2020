public interface IBoatPart : IFixable, IExplodeable, IDamage
{
    IBoatPart Part { get; }
    float Health { get; }
    float MaxHealth { get; }
}