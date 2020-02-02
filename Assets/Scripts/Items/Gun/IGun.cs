public interface IGun : IGrabable
{
    GunConfig Config { get; set; }

    void TimeUpdate(float deltaTime);
    bool Shoot();
    void Reload();
}