using Amazon.S3;
using Amazon.S3.Model;
using Lottery.Infra.CrossCutting.Storage.Abstractions;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Lottery.Infra.CrossCutting.Storage.Abstractions.Models;
using System.Collections.Generic;

namespace Lottery.Infra.CrossCutting.Storage.S3
{
    public class S3FileStorage : IFileStorage
    {
        private readonly IAmazonS3 _amazonS3Client;
        private readonly string _bucketName;

        public S3FileStorage(IAmazonS3 amazonS3Client, string bucketName)
        {
            _amazonS3Client = amazonS3Client ?? throw new ArgumentException(nameof(amazonS3Client));
            if (string.IsNullOrWhiteSpace(bucketName))
            {
                throw new ArgumentNullException("Argument is null or empty.", nameof(bucketName));
            }
            this._bucketName = bucketName;
        }

        public async Task AddFile(string fileName, string filePath, Stream fileStream, CancellationToken cancelationToken = default)
        {
            var putObjectRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                InputStream = fileStream,
                Key = $"{filePath}{fileName}"
            };

            await _amazonS3Client.PutObjectAsync(putObjectRequest, cancelationToken);
        }

        public async Task RemoveFile(string fileName, string filePath, CancellationToken cancelationToken = default)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = $"{filePath}{fileName}"
            };

            await _amazonS3Client.DeleteObjectAsync(deleteObjectRequest, cancelationToken);
        }

        public async Task<Stream> GetFileStream(string fileName, string filePath, CancellationToken cancelationToken = default)
        {
            var getObjectRequest = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = $"{filePath}{fileName}"
            };

            var getObjectResponse = await _amazonS3Client.GetObjectAsync(getObjectRequest, cancelationToken);
            return getObjectResponse.ResponseStream;
        }

        public async Task<IEnumerable<FileStorageListItem>> GetFileList(string prefix, CancellationToken cancelationToken = default)
        {
            var result = new List<FileStorageListItem>();
            string continuationToken;
            do
            {

                var listObjectRequest = new ListObjectsV2Request
                {
                    BucketName = _bucketName,
                    Prefix = prefix
                };

                var listObjectResponse = await _amazonS3Client.ListObjectsV2Async(listObjectRequest, cancelationToken);
                IEnumerable<FileStorageListItem> storageItemsList = ConvertListObjectsV2ResponseToFileStorageList(listObjectResponse);

                result.AddRange(storageItemsList);
                continuationToken = listObjectResponse.ContinuationToken;
            } while (!string.IsNullOrEmpty(continuationToken));
            return result;
        }

        private static IEnumerable<FileStorageListItem> ConvertListObjectsV2ResponseToFileStorageList(ListObjectsV2Response listObjectResponse)
        {
            return listObjectResponse.S3Objects.Where(x => x.Size > 0).Select(x => new FileStorageListItem
            {
                FileName = x.Key.Split('/').Last(),
                FileNameWithFullPath = x.Key,
                Size = x.Size
            });
        }

        public Task<IEnumerable<FileStorageListItem>> GetFileList(CancellationToken cancelationToken = default)
        {
            return GetFileList(string.Empty, cancelationToken);
        }
    }
}
