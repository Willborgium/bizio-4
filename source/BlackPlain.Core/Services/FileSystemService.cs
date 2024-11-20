using Newtonsoft.Json;
using System.Text;

namespace BlackPlain.Core.Services
{
    public class FileSystemService : IFileSystemService
    {
        public async Task<T?> ReadFileAsync<T>(string path, CancellationToken cancellationToken = default)
        {
            string? data = null;

            var p = Path.Combine(Directory.GetCurrentDirectory(), path);

            // make this work for app package files and system files
            
            if (!File.Exists(p))
            {
                using (var file = File.Create(p))
                {
                    // does this work?
                }

                return default;
            }

            using (var reader = new StreamReader(p))
            {
                data = await reader.ReadToEndAsync(cancellationToken);
            }
            
            return JsonConvert.DeserializeObject<T>(data ?? string.Empty);
        }

        public async Task SaveFileAsync<T>(string path, T data, CancellationToken cancellationToken = default)
        {
            var serializedData = JsonConvert.SerializeObject(data);
            var dataBuilder = new StringBuilder(serializedData);

            using (var writer = new StreamWriter(await FileSystem.OpenAppPackageFileAsync(path)))
            {
                await writer.WriteAsync(dataBuilder, cancellationToken);
            }
        }
    }
}
