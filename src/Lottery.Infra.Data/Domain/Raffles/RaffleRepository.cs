using Lottery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lottery.Infra.Data.Domain.Raffles
{
    public class RaffleRepository : IRaffleRepository
    {
        private LotteryContext _lotteryContext;
        public RaffleRepository()
        {
            _lotteryContext = new LotteryContext();
        }
        public void Add(Raffle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Raffle entity)
        {
            throw new NotImplementedException();
        }

        public Raffle[] GetAll()
        {
            var rng = new Random();
            var raffleCollection = Enumerable.Range(1, 5).Select(index => new Raffle(
                Guid.NewGuid(),
                _lotteryContext.MockTitles[rng.Next(_lotteryContext.MockTitles.Length)],
                _lotteryContext.MockDescriptions[rng.Next(_lotteryContext.MockDescriptions.Length)],
                "https://mdbootstrap.com/img/Photos/Others/img%20(27).jpg",
                DateTime.Today,
                DateTime.UtcNow,
                _lotteryContext.MockNames[rng.Next(_lotteryContext.MockNames.Length)]
            ));
            return raffleCollection.ToArray();
        }

        public Raffle GetById(object id)
        {
            if (!(id is Guid validId))
            {
                throw new ArgumentException("Invalid argument type.", nameof(id));
            }
            return GetAll().FirstOrDefault();
        }

        public IQueryable<Raffle> Query(Expression<Func<Raffle, bool>> filter)
            => GetAll().Where(filter.Compile()).AsQueryable();

        public void Update(Raffle entity)
        {
            throw new NotImplementedException();
        }
    }
}
