using Lottery.Application.Configuration.Queries;
using Lottery.Data.Models;
using System;
using System.Collections.Generic;

namespace Lottery.Application.Queries
{
    public class GetRaffleParticipantsQuery : IQuery<IEnumerable<Participant>>
    {
        public Guid RaffleId { get; set; }
        public GetRaffleParticipantsQuery(Guid raffleId)
        {
            RaffleId = raffleId;
        }
    }
}
