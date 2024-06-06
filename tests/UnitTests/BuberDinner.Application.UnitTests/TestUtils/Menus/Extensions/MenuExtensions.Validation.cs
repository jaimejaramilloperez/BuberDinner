using BuberDinner.Application.Menus.CreateMenu;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;

public static partial class MenuExtensions
{
    public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
    {
        menu.Name.Should().Be(command.Name);
        menu.Description.Should().Be(command.Description);
        menu.Sections.Should().HaveSameCount(command.Sections);
        menu.Sections.Zip(command.Sections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));

        static void ValidateSection(MenuSection section, CreateMenuSectionCommand menuSection)
        {
            section.Id.Should().NotBeNull();
            section.Name.Should().Be(menuSection.Name);
            section.Description.Should().Be(menuSection.Description);
            section.Items.Should().HaveSameCount(menuSection.Items);
            section.Items.Zip(menuSection.Items).ToList().ForEach(pair => ValidateItem(pair.First, pair.Second));
        }

        static void ValidateItem(MenuItem item, CreateMenuItemCommand menuItem)
        {
            item.Id.Should().NotBeNull();
            item.Name.Should().Be(menuItem.Name);
            item.Description.Should().Be(menuItem.Description);
        }
    }
}
