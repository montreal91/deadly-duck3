
namespace Api.Game.Adapters {


public class CreateNewGameAdapter : App.Game.Ports.CreateNewGamePort {
  private Domain.Game.Commands.CreateNewGame createNewGameCommand;

  public CreateNewGameAdapter(
      Domain.Game.Commands.CreateNewGame createNewGameCommand
  ) {
    this.createNewGameCommand = createNewGameCommand;
  }

  void App.Game.Ports.CreateNewGamePort.Handle(
      string gameHandle, int maxSeasons
  ) {
    createNewGameCommand.Handle(gameHandle, maxSeasons);
  }
}

}  // namespace Api.Game.Adapters
