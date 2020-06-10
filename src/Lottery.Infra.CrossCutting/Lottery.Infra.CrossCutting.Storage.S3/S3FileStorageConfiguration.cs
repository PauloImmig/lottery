using Lottery.Infra.CrossCutting.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Infra.CrossCutting.Storage.S3
{
    public class S3FileStorageConfiguration : IFileStorageConfiguration
    {
        public string Bucket { get; set; }
    }
}
