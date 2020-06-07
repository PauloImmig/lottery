using Lottery.Infra.CrossCutting.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Infra.CrossCutting.Storage
{
    public class FileStorageFactory : IFileStorageFactory
    {
        private IFileStorage _fileStorage;

        private readonly object _sync = new object();

        private volatile bool _disposed;

        public IFileStorage CreateFileStorage(IFileStorageProvider provider)
        {
            if (CheckDisposed())
            {
                throw new ObjectDisposedException(nameof(FileStorageFactory));
            }

            lock (_sync)
            {
                if (_fileStorage == null)
                {
                    _fileStorage = provider.CreateFileStorage();
                }

                return _fileStorage;
            }
        }

        protected virtual bool CheckDisposed() => _disposed;

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _fileStorage = null;
            }
        }
    }
}
