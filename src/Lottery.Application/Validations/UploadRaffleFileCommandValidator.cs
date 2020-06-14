using FluentValidation;
using Lottery.Application.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Application.Validations
{
    public class UploadRaffleFileCommandValidator : AbstractValidator<UploadRaffleFileCommand>
    {
        public UploadRaffleFileCommandValidator(ILogger<UploadRaffleFileCommand> logger)
        {
            RuleFor(fileUpload => fileUpload.FileName).NotEmpty();
            RuleFor(fileUpload => fileUpload.FilePath).NotEmpty();
            RuleFor(fileUpload => fileUpload.Id).NotEmpty();
            RuleFor(fileUpload => fileUpload.Stream).NotEmpty();

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
