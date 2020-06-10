using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public class NullFileStorageFactory : IFileStorageFactory
    {
        public static readonly NullFileStorageFactory Instance = new NullFileStorageFactory();

        public IFileStorage CreateFileStorage<TFileStorageProvider>() where TFileStorageProvider : IFileStorageProvider
            => NullFileStorage.Instance;

        public IFileStorage CreateFileStorage<TFileStorageProvider>(IFileStorageConfiguration fileStorageConfiguration) where TFileStorageProvider : IFileStorageProvider
            => NullFileStorage.Instance;

        public void Dispose()
        {
        }
    }
}
