using MediatR;
using OcsTestWork.Application.Helpers;

namespace OcsTestWork.Application.Abstractions.Messaging;

public interface IAppRequest : IRequest<Result>
{
}

public interface IAppRequest<TResponse> : IRequest<Result<TResponse>>
{
}