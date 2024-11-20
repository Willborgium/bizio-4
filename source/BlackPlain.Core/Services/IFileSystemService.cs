namespace BlackPlain.Core
{
    public interface IFileSystemService
    {
        Task<T?> ReadFileAsync<T>(string path, CancellationToken cancellationToken = default);

        Task SaveFileAsync<T>(string path, T data, CancellationToken cancellationToken = default);
    }
}
