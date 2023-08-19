
namespace Game.Adapters {


public class CreateNewGameAdapter : Game.App.Ports.CreateNewGamePort {
  private Game.Domain.Commands.CreateNewGame createNewGameCommand;

  public CreateNewGameAdapter(
      Game.Domain.Commands.CreateNewGame createNewGameCommand
  ) {
    this.createNewGameCommand = createNewGameCommand;
  }

  void Game.App.Ports.CreateNewGamePort.Handle(
      string gameHandle, int maxSeasons
  ) {
    createNewGameCommand.Handle(gameHandle, maxSeasons);
  }
}

}  // namespace Game.Adapters
