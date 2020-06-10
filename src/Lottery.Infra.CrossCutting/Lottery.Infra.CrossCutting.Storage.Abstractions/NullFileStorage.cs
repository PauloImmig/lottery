using Lottery.Infra.CrossCutting.Storage.Abstractions.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public class NullFileStorage : IFileStorage
    {
        public static NullFileStorage Instance { get; } = new NullFileStorage();

        public NullFileStorage()
        {
        }

        public async Task AddFile(string fileName, string filePath, Stream fileStream, CancellationToken cancelationToken = default)
        {
        }

        public async Task RemoveFile(string fileName, string filePath, CancellationToken cancelationToken = default)
        {
        }

        public Task<Stream> GetFileStream(string fileName, string filePath, CancellationToken cancelationToken = default)
        {
            return Task.FromResult(new MemoryStream() as Stream);
        }

        public Task<IEnumerable<FileStorageListItem>> GetFileList(string prefix, CancellationToken cancelationToken = default)
        {
            return Task.FromResult(Enumerable.Empty<FileStorageListItem>());
        }

        public Task<IEnumerable<FileStorageListItem>> GetFileList(CancellationToken cancelationToken = default)
        {
            return GetFileList(string.Empty, cancelationToken);
        }
    }
}
