using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu;
using BuberDinner.Infrastructure.Persistence.Configurations;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor;

    public BuberDinnerDbContext(
        DbContextOptions<BuberDinnerDbContext> options,
        PublishDomainEventInterceptor publishDomainEventInterceptor)
        : base(options)
    {
        _publishDomainEventInterceptor = publishDomainEventInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<List<IDomainEvent>>();

        modelBuilder.ApplyConfiguration(new MenuConfigurations());
    }

    public DbSet<Menu> Menus { get; set; }
}
