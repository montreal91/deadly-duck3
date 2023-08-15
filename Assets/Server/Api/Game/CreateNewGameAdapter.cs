
namespace Api.Game.Adapters {

using Application.Game;

public class CreateNewGameAdapter : Ports.CreateNewGamePort {
  private Handlers.CreateNewGameCommand createNewGameCommand;

  public CreateNewGameAdapter(
      Handlers.CreateNewGameCommand createNewGameCommand
  ) {
    this.createNewGameCommand = createNewGameCommand;
  }

  public void Handle(string gameHandle, int maxSeasons) {
    createNewGameCommand.Handle(gameHandle, maxSeasons);
  }
}

}  // namespace Api.Game.Adapters
