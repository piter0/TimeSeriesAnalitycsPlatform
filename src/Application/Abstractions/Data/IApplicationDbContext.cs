﻿namespace Application.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        //DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
