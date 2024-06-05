using BuberDinner.Domain.Menu.Events;
using MediatR;

namespace BuberDinner.Application.Menus.CreateMenu;

public class MenuCreatedHandler : INotificationHandler<MenuCreated>
{
    public async Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
