﻿namespace Application.Abstractions.Messaging
{
    public interface ICommandHandler<in TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
