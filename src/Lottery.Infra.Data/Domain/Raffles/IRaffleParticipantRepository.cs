using Lottery.Data.Models;
using System;
using System.Linq;

namespace Lottery.Infra.Data.Domain.Raffles
{
    public interface IRaffleParticipantRepository : IRepository<Participant>
    {
        IQueryable<Participant> GetByRaffleId(Guid id);
    }
}
