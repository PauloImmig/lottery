using Lottery.Infra.CrossCutting.Storage;
using Lottery.Infra.CrossCutting.Storage.S3;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace Lottery.Infra.CrossCuting.Storage.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var s3Configuration = new S3FileStorageConfiguration { Bucket = "123teste" };

            var s3provider = new S3FileStorageProvider(configuration, s3Configuration);
            var fileStorage = new FileStorageFactory().CreateFileStorage(s3provider);
        }
    }
}
