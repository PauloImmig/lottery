using Lottery.Application.Configuration.Commands;
using Lottery.Infra.CrossCutting.Storage.Abstractions;
using Lottery.Infra.CrossCutting.Storage.S3;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Application.Commands.Handlers
{
    public class UploadRaffleFileCommandHandler : ICommandHandler<UploadRaffleFileCommand, Guid>
    {
        private readonly IFileStorageFactory _fileStorageFactory;

        public UploadRaffleFileCommandHandler(IFileStorageFactory fileStorageFactory)
        {
            _fileStorageFactory = fileStorageFactory;
        }

        public async Task<Guid> Handle(UploadRaffleFileCommand request, CancellationToken cancellationToken)
        {
            var fileStorage = _fileStorageFactory.CreateFileStorage<IS3FileStorageProvider>();
            await fileStorage.AddFile(request.FileName, request.FilePath, request.Stream);
            return request.Id;
        }
    }
}
