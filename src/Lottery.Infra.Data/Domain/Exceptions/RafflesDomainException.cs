using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Infra.Data.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class RafflesDomainException : Exception
    {
        public RafflesDomainException()
        { }

        public RafflesDomainException(string message)
            : base(message)
        { }

        public RafflesDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
