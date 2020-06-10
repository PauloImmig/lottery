using Lottery.Infra.CrossCutting.Storage.Abstractions;
using Lottery.Infra.CrossCutting.Storage.S3;
using Microsoft.Extensions.Configuration;
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

        private IDictionary<Type, Type> _types = new Dictionary<Type, Type>
        {
            [typeof(IS3FileStorageProvider)] = typeof(S3FileStorageProvider)
        };
        private readonly IConfiguration _configuration;

        public FileStorageFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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

        public IFileStorage CreateFileStorage<TFileStorageProvider>(IFileStorageConfiguration fileStorageConfiguration) where TFileStorageProvider : IFileStorageProvider
        {
            if (CheckDisposed())
            {
                throw new ObjectDisposedException(nameof(FileStorageFactory));
            }

            lock (_sync)
            {
                if (_fileStorage == null)
                {
                    if (_types.TryGetValue(typeof(TFileStorageProvider), out Type providerType))
                    {
                        var provider = Activator.CreateInstance(providerType, _configuration, fileStorageConfiguration) as IFileStorageProvider;
                        _fileStorage = provider.CreateFileStorage();
                        return _fileStorage;
                    }                    
                }
                return _fileStorage;
            }
            throw new NotSupportedException("Invalid file storage provider type.");
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
