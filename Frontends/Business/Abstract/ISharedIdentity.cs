namespace Business.Abstract;

public interface ISharedIdentity
{
    public string GetUserId { get; }
    public string Name { get; }
}
