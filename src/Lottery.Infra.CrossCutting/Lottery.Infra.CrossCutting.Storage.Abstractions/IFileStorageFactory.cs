using System;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public interface IFileStorageFactory : IDisposable
    {        
        IFileStorage CreateFileStorage(IFileStorageProvider provider);
        IFileStorage CreateFileStorage<TFileStorageProvider>(IFileStorageConfiguration fileStorageConfiguration) where TFileStorageProvider : IFileStorageProvider;
    }
}
