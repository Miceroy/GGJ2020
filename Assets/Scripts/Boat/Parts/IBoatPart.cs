public interface IBoatPart : IFixable, IExplodeable, IDamage
{
    float Health { get; }
}