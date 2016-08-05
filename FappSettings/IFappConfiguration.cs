namespace FappSettings
{
    public interface IFappConfiguration<T>
    {
        string Key { get; }
        T Parse(string value);
    }
}
