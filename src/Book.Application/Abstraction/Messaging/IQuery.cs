using Book.Domain.Abstraction;
using MediatR;

namespace Book.Application.Abstraction.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>    
    {
    }
}
