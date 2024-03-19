﻿using System.Reflection;
using Contract.Extraction.Api.Domain.Entities;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Filme> Filme => Set<Filme>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Filme>()
            .ToTable("filme");

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var output = await base.SaveChangesAsync(cancellationToken);
        return output;
    }
}