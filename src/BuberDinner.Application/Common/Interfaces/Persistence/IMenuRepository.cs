using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);
}
