using Lottery.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lottery.Application.Commands
{
    public class UploadRaffleFileCommand : CommandBase<Guid>
    {
        public string FileName { get; }
        public string FilePath { get; }
        public Stream Stream { get; }
        public UploadRaffleFileCommand(
            string fileName,
            string filePath,
            Stream stream)
        {
            FileName = fileName;
            FilePath = filePath;
            Stream = stream;
        }
    }
}
