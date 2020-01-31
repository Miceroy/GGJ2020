public interface IGrabable
{
    IGrabable Grab();
    void Release();
    bool IsGrabbed { get; }
}
