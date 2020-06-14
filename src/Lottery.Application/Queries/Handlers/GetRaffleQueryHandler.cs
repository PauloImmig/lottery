using Lottery.Application.Configuration.Queries;
using Lottery.Data.Models;
using Lottery.Infra.Data.Domain.Raffles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Application.Queries.Handlers
{
    public class GetRaffleQueryHandler : IQueryHandler<GetRaffleQuery, IEnumerable<Raffle>>
    {
        private readonly IRaffleRepository _repository;

        public GetRaffleQueryHandler(IRaffleRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Raffle>> Handle(GetRaffleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAll().AsEnumerable());
        }
    }
}
