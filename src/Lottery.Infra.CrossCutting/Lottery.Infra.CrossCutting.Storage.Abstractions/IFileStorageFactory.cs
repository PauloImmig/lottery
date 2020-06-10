using System;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public interface IFileStorageFactory : IDisposable
    {
        IFileStorage CreateFileStorage<TFileStorageProvider>() where TFileStorageProvider : IFileStorageProvider;
        IFileStorage CreateFileStorage<TFileStorageProvider>(IFileStorageConfiguration fileStorageConfiguration) where TFileStorageProvider : IFileStorageProvider;
    }
}
