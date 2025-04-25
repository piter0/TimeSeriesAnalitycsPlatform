﻿namespace Application.Abstractions.Messaging
{
    public interface ICommandHandler<in TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default);
    }

    //public interface ICommandHandler<in TCommand>
    //{
    //    Task Handle(TCommand command, CancellationToken cancellationToken = default);
    //}
}
