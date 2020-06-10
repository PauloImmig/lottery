using Lottery.Infra.CrossCuting.Storage.Tests.Fixtures;
using Lottery.Infra.CrossCutting.Storage;
using Lottery.Infra.CrossCutting.Storage.Abstractions.Models;
using Lottery.Infra.CrossCutting.Storage.S3;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Lottery.Infra.CrossCutting.Storage.Abstractions;

namespace Lottery.Infra.CrossCuting.Storage.Tests
{
    public class S3FileStorageTests : IClassFixture<ServiceProviderFixture>
    {
        private ServiceProvider _serviceProvider;
        private IFileStorageFactory _fileStorageFactory;

        public S3FileStorageTests(ServiceProviderFixture serviceProviderFixture)
        {
            serviceProviderFixture.ServiceCollection
                .AddTransient<IFileStorageFactory, FileStorageFactory>()
                .AddTransient(typeof(IConfiguration), _ => new ConfigurationBuilder()
                                                            .SetBasePath(Directory.GetCurrentDirectory())
                                                            .AddJsonFile("appsettings.json")
               .Build());

            _serviceProvider = serviceProviderFixture.ServiceCollection.BuildServiceProvider();
            _fileStorageFactory = _serviceProvider.GetService<IFileStorageFactory>();
        }

        [Fact]
        public async Task AddObject_ShouldWork()
        {
            var s3Configuration = new S3FileStorageConfiguration { Bucket = "lotteryv2" };

            var fileStorage = _fileStorageFactory.CreateFileStorage<IS3FileStorageProvider>(s3Configuration);
            var memoryStream = new MemoryStream();
            var fileContentText = "fileContentTest";
            var buffer = Encoding.Default.GetBytes(fileContentText);
            memoryStream.Write(buffer, 0, buffer.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);

            await fileStorage.AddFile("test.txt", "testfolder/", memoryStream);
        }

        [Fact]
        public async Task GetObject_ShouldWork()
        {
            var s3Configuration = new S3FileStorageConfiguration { Bucket = "lotteryv2" };
            var fileStorage = _fileStorageFactory.CreateFileStorage<IS3FileStorageProvider>(s3Configuration);

            var resultFileStream = await fileStorage.GetFileStream("test.txt", "testfolder/");
            var resultFileStreamContent = new StreamReader(resultFileStream).ReadToEnd();

            Assert.Equal("fileContentTest", resultFileStreamContent);
        }

        [Fact]
        public async Task RemoveObject_ShouldWork()
        {
            var s3Configuration = new S3FileStorageConfiguration { Bucket = "lotteryv2" };
            var fileStorage = _fileStorageFactory.CreateFileStorage<IS3FileStorageProvider>(s3Configuration);

            await fileStorage.RemoveFile("test.txt", "testfolder/");
        }

        [Fact]
        public async Task ListObjects_ShouldWork()
        {
            var s3Configuration = new S3FileStorageConfiguration { Bucket = "lotteryv2" };
            var fileStorage = _fileStorageFactory.CreateFileStorage<IS3FileStorageProvider>(s3Configuration);
            var fileList = await fileStorage.GetFileList();

            Assert.IsAssignableFrom<IEnumerable<FileStorageListItem>>(fileList);
        }
    }
}
