
using NUnit.Framework;

using Domain;

public class CreateNewGameCommandTest {
    private Domain.Game.GameRepository gameRepository;
    private Domain.Game.Port.CreateNewGameCommandImpl commandImpl;

    [OneTimeSetUp]
    public void SetUp() {
        gameRepository = new MockGameRepository();
        commandImpl = new Domain.Game.Port.CreateNewGameCommandImpl(
            gameRepository
        );
        gameRepository.Save(
            new Domain.Game.Game("ExistingName", 5)
        );
    }

    [Test]
    public void CreateNewGameBaseCase() {
        Assert.False(gameRepository.DoesGameExist("TestGame"));

        commandImpl.Handle("TestGame", 5);
        var game = gameRepository.GetGameByHandle("TestGame");

        Assert.True(gameRepository.DoesGameExist("TestGame"));
    }

    [Test]
    public void SameGameNameError() {
        Assert.True(gameRepository.DoesGameExist("ExistingName"));

        Assert.Throws<Domain.Exceptions.GameCreationException>(
            () => commandImpl.Handle("ExistingName", 5)
        );
    }

    [Test]
    public void InvalidSeasonNumber() {
        Assert.Throws<Domain.Exceptions.GameCreationException>(
            () => commandImpl.Handle("TestGame", 6)
        );
    }
}
