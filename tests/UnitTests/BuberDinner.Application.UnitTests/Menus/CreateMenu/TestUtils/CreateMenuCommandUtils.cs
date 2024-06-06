using BuberDinner.Application.Menus.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Menus.CreateMenu.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(List<CreateMenuSectionCommand>? sections = null)
    {
        return new CreateMenuCommand(
            HostId: Constants.Host.Id,
            Name: Constants.Menu.Name,
            Description: Constants.Menu.Description,
            Sections: sections ?? CreateMenuSections());
    }

    public static List<CreateMenuSectionCommand> CreateMenuSections(
        int sectionCount = 1,
        List<CreateMenuItemCommand>? items = null)
    {
        return Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                Name: Constants.Menu.SectionNameFromIndex(index),
                Description: Constants.Menu.SectionDescriptionFromIndex(index),
                Items: items ?? CreateMenuItems()))
            .ToList();
    }

    public static List<CreateMenuItemCommand> CreateMenuItems(int itemCount = 1)
    {
        return Enumerable.Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                Name: Constants.Menu.ItemNameFromIndex(index),
                Description: Constants.Menu.ItemDescriptionFromIndex(index)))
            .ToList();
    }
}
