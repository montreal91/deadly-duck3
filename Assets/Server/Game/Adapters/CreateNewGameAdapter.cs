
namespace Game.Adapters {


public class CreateNewGameAdapter : Game.App.Ports.CreateNewGamePort {
  private Game.App.Handlers.CreateNewGameCommand createNewGameCommand;

  public CreateNewGameAdapter(
      Game.App.Handlers.CreateNewGameCommand createNewGameCommand
  ) {
    this.createNewGameCommand = createNewGameCommand;
  }

  void Game.App.Ports.CreateNewGamePort.Handle(
      Game.App.Ports.CreateNewGameDto dto
  ) {
    createNewGameCommand.Handle(
        new Game.Domain.Commands.CreateNewGame(dto.gameHandle, dto.maxSeasons)
    );
  }
}

}  // namespace Game.Adapters
