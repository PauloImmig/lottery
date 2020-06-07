namespace Lottery.Infra.CrossCutting.Storage.Abstractions
{
    public class NullFileStorageProvider : IFileStorageProvider
    {
        public static NullFileStorageProvider Instance { get; } = new NullFileStorageProvider();

        public NullFileStorageProvider()
        {
        }

        public IFileStorage CreateFileStorage()
        {
            return NullFileStorage.Instance;
        }

        public void Dispose()
        {
        }
    }
}
