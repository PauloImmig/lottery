using Lottery.Application.Configuration.Queries;
using Lottery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Application.Queries
{
    public class GetRaffleByIdQuery : IQuery<Raffle>
    {
        public Guid RaffleId { get; set; }
        public GetRaffleByIdQuery(Guid raffleId) => RaffleId = raffleId;
    }
}
