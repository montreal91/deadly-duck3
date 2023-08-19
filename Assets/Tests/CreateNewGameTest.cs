
using NUnit.Framework;


public class CreateNewGameCommandTest {
  private Game.App.Ports.GameRepository gameRepository;
  private Game.Domain.Commands.CreateNewGame commandHandler;

  [OneTimeSetUp]
  public void SetUp() {
    gameRepository = new MockGameRepository();
    commandHandler = new Game.App.Handlers.CreateNewGameCommand(
      gameRepository
    );
    gameRepository.Save(
      new Game.Domain.Model.Game("ExistingName", 5)
    );
  }

  [Test]
  public void CreateNewGameBaseCase() {
    Assert.False(gameRepository.DoesGameExist("TestGame"));

    commandHandler.Handle("TestGame", 5);
    var game = gameRepository.GetGameByHandle("TestGame");

    Assert.True(gameRepository.DoesGameExist("TestGame"));
  }

  [Test]
  public void SameGameNameError() {
    Assert.True(gameRepository.DoesGameExist("ExistingName"));

    Assert.Throws<Game.Core.Exceptions.GameCreationException>(
      () => commandHandler.Handle("ExistingName", 5)
    );
  }

  [Test]
  public void InvalidSeasonNumber() {
    Assert.Throws<Game.Core.Exceptions.GameCreationException>(
      () => commandHandler.Handle("TestGame", 6)
    );
  }
}
