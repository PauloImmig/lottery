using Lottery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lottery.Infra.Data.Domain.Raffles
{
    public class RaffleParticipantRepository : IRaffleParticipantRepository
    {
        private LotteryContext _lotteryContext;

        public RaffleParticipantRepository()
        {
            _lotteryContext = new LotteryContext();
        }

        public void Add(Participant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Participant entity)
        {
            throw new NotImplementedException();
        }

        public Participant[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Participant GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Participant> GetByRaffleId(Guid id)
        {
            var rng = new Random();
            var participants = Enumerable.Range(1, 30).Select(index => new Participant(
                Guid.NewGuid(),
                id,
                _lotteryContext.MockNames[rng.Next(_lotteryContext.MockNames.Length)],
                $"{_lotteryContext.MockNames[rng.Next(_lotteryContext.MockNames.Length)].Replace(" ", "")}@gmail.com"
            )).ToList();
            for (int i = 0; i < participants.Count(); i++)
            {
                participants[i].AddRandomNumbers(5);
            }
            return participants.AsQueryable();
        }

        public IQueryable<Participant> Query(Expression<Func<Participant, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Participant entity)
        {
            throw new NotImplementedException();
        }
    }
}
