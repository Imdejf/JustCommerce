﻿using MediatR;

namespace E_Commerce.Application.Common.Interfaces
{
    public interface IRequestWrapper<T> : IRequest<T>
    {

    }

    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequestWrapper<TOut>
    {

    }
}
