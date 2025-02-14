﻿using Book.Domain.Abstraction;
using MediatR;

namespace Book.Application.Abstraction.Messaging
{
    public interface ICommand : IRequest<Result>,IBaseCommand
    {
    }    
    
    public interface ICommand<TResponse> : IRequest<Result<TResponse>> ,IBaseCommand    
    {
    }

    public interface IBaseCommand
    {

    }
}
