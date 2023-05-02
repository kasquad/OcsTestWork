using MediatR;
using OcsTestWork.Application.Helpers;

namespace OcsTestWork.Application.Abstractions.Messaging;

public interface IAppRequestHandler<TCommand> : IRequestHandler<TCommand,Result> 
    where TCommand : IAppRequest
{
}

public interface IAppRequestHandler<TCommand,TResponse> : 
    IRequestHandler<TCommand,Result<TResponse>> 
    where TCommand : IAppRequest<TResponse>
{
}