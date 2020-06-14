using MediatR;

namespace Lottery.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
