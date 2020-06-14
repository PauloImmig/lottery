using Lottery.Application.Configuration.Queries;
using Lottery.Data.Models;
using Lottery.Infra.Data.Domain.Raffles;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Application.Queries.Handlers
{
    public class GetRaffleParticipantsQueryHandler : IQueryHandler<GetRaffleParticipantsQuery, IEnumerable<Participant>>
    {
        private readonly IRaffleParticipantRepository _repository;

        public GetRaffleParticipantsQueryHandler(IRaffleParticipantRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Participant>> Handle(GetRaffleParticipantsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetByRaffleId(request.RaffleId).AsEnumerable());
        }
    }
}
