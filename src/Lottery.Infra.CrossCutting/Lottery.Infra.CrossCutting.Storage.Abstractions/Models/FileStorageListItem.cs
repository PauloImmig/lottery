using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lottery.Infra.CrossCutting.Storage.Abstractions.Models
{
    public class FileStorageListItem
    {
        public string FileNameWithFullPath { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
    }
}
