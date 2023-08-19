
using NUnit.Framework;

using CreateNewGameCommand = Game.Domain.Commands.CreateNewGame;

public class CreateNewGameCommandTest {
  private Game.App.Ports.GameRepository gameRepository;
  private Game.App.Handlers.CreateNewGameCommand commandHandler;

  private readonly int EXISTING_SEASONS = 10;

  [SetUp]
  public void Init() {
    gameRepository = new MockGameRepository();
    commandHandler = new Game.App.Handlers.CreateNewGameCommand(
      gameRepository
    );
    gameRepository.Save(
      new Game.Domain.Model.Game("ExistingName", EXISTING_SEASONS)
    );
  }

  [Test]
  public void CreateNewGameBaseCase() {
    Assert.False(gameRepository.DoesGameExist("TestGame"));

    commandHandler.Handle(new CreateNewGameCommand("TestGame", 5));
    var game = gameRepository.GetGameByHandle("TestGame");

    Assert.True(gameRepository.DoesGameExist("TestGame"));
  }

  [Test]
  public void SameGameNameError() {
    Assert.True(gameRepository.DoesGameExist("ExistingName"));


    int res = commandHandler.Handle(
        new CreateNewGameCommand("ExistingName", 5)
    );
    var game = gameRepository.GetGameByHandle("ExistingName");

    Assert.AreEqual(1, res);
    Assert.AreEqual(EXISTING_SEASONS, game.MaxSeasons);
  }

  [Test]
  public void InvalidSeasonNumber() {
    int res = commandHandler.Handle(new CreateNewGameCommand("TestGame", 6));
    Assert.AreEqual(1, res);
    Assert.False(gameRepository.DoesGameExist("TestGame"));
  }
}
