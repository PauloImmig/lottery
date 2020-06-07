using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public class NullFileStorageProviderFactory : IFileStorageFactory
    {
        public static readonly NullFileStorageProviderFactory Instance = new NullFileStorageProviderFactory();

        public IFileStorage CreateFileStorage(IFileStorageProvider provider)
        {
            return NullFileStorage.Instance;
        }

        public void Dispose()
        {
        }
    }
}
