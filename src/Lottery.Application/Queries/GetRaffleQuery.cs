using Lottery.Application.Configuration.Queries;
using Lottery.Data.Models;
using System.Collections.Generic;

namespace Lottery.Application.Queries
{
    public class GetRaffleQuery : IQuery<IEnumerable<Raffle>>
    {
        public GetRaffleQuery()
        {
        }
    }
}
