
using NUnit.Framework;


public class CreateNewGameCommandTest {
  private Domain.Game.GameRepository gameRepository;
  private App.Game.Handlers.CreateNewGameCommand commandHandler;

  [OneTimeSetUp]
  public void SetUp() {
    gameRepository = new MockGameRepository();
    commandHandler = new App.Game.Handlers.CreateNewGameCommand(
      gameRepository
    );
    gameRepository.Save(
      new Domain.Game.Game("ExistingName", 5)
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

    Assert.Throws<Domain.Exceptions.GameCreationException>(
      () => commandHandler.Handle("ExistingName", 5)
    );
  }

  [Test]
  public void InvalidSeasonNumber() {
    Assert.Throws<Domain.Exceptions.GameCreationException>(
      () => commandHandler.Handle("TestGame", 6)
    );
  }
}
