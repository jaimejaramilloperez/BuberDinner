using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.CreateMenu.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using BuberDinner.Domain.Menu;
using ErrorOr;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.CreateMenu;

public class CreateMenuCommandHandlerTest
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTest()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateMenuSections(sectionCount: 3)),
        };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateMenuSections(
                    sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateMenuItems(itemCount: 3))),
        };
    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        // Act
        ErrorOr<Menu> result = await _handler.Handle(createMenuCommand, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
    }
}
