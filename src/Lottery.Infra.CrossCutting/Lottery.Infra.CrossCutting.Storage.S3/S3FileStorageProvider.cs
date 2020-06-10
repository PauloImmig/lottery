using Amazon.S3;
using Lottery.Infra.CrossCutting.Storage.Abstractions;
using Microsoft.Extensions.Configuration;
using System;

namespace Lottery.Infra.CrossCutting.Storage.S3
{
    public class S3FileStorageProvider : IS3FileStorageProvider
    {
        private const string S3BucketName = "FileStorage:S3:BucketName";
        private readonly IConfiguration _configuration;
        private S3FileStorageConfiguration _fileStorageConfiguration;

        public S3FileStorageProvider(IConfiguration configuration) : this(configuration, null)
        {
        }

        public S3FileStorageProvider(IConfiguration configuration, IFileStorageConfiguration fileStorageConfiguration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _fileStorageConfiguration = fileStorageConfiguration as S3FileStorageConfiguration;
            if (_fileStorageConfiguration == null)
            {
                LoadFileStorageConfigurationFromSettings();
            }
        }
        
        private void LoadFileStorageConfigurationFromSettings()
        {
            var bucketName = _configuration.GetValue<string>(S3BucketName);
            if (string.IsNullOrWhiteSpace(bucketName))
            {
                throw new ArgumentException("BucketName should be set. It can be done through IConfiguration key or IFileStorageConfiguration.", nameof(bucketName));
            }

            _fileStorageConfiguration = new S3FileStorageConfiguration
            {
                Bucket = bucketName
            };
        }

        public IFileStorage CreateFileStorage()
        {
            var awsOptions = _configuration.GetAWSOptions();
            var amazonS3Cient = awsOptions.CreateServiceClient<IAmazonS3>();
            return new S3FileStorage(amazonS3Cient, _fileStorageConfiguration.Bucket);
        }

        public void Dispose()
        {
        }
    }
}
