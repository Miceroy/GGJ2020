public interface IExplodeable
{
    float Damage { get; }
    float Radius { get; }
    bool IsExploded { get; }

    bool Explode();
}