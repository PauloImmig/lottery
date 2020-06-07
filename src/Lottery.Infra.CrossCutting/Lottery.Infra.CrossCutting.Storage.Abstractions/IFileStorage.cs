using Lottery.Infra.CrossCutting.Storage.Abstractions.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public interface IFileStorage
    {
        Task AddFile(string fileName, string filePath, Stream fileStream, CancellationToken cancelationToken = default);

        Task RemoveFile(string fileName, string filePath, CancellationToken cancelationToken = default);
        Task<Stream> GetFileStream(string fileName, string filePath, CancellationToken cancelationToken = default);
        Task<IEnumerable<FileStorageListItem>> GetFileList(string prefix, CancellationToken cancelationToken = default);
    }
}
