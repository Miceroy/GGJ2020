public interface IGun : IGrabable
{
    void TimeUpdate(float deltaTime);
    bool Shoot();
    void Reload();
}