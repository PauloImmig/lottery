using Lottery.Application.Configuration.Queries;
using Lottery.Data.Models;
using Lottery.Infra.Data.Domain.Raffles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Application.Queries.Handlers
{
    public class GetRaffleByIdQueryHandler : IQueryHandler<GetRaffleByIdQuery, Raffle>
    {
        private readonly IRaffleRepository _repository;

        public GetRaffleByIdQueryHandler(IRaffleRepository repository)
        {
            _repository = repository;
        }

        public Task<Raffle> Handle(GetRaffleByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetById(request.RaffleId));
        }
    }
}
