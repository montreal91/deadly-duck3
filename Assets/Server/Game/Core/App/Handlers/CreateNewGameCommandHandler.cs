using System.Collections.Generic;

using Lib;


namespace Game.App.Handlers {

using GameModel = Game.Domain.Model.Game;
using CreateNewGame = Game.Domain.Commands.CreateNewGame;

public class CreateNewGameCommand : CommandHandler<CreateNewGame, int> {
  private readonly Game.App.Ports.GameRepository gameRepository;

  public CreateNewGameCommand(Game.App.Ports.GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  public int Handle(Game.Domain.Commands.CreateNewGame command) {
    if (gameRepository.DoesGameExist(command.gameHandle)) {
      return 1;
    }

    if (!GameModel.GAME_LENGTHS.Contains(command.maxSeasons)) {
      return 1;
    }

    var game = new GameModel(command.gameHandle, command.maxSeasons);
    gameRepository.Save(game);
    return 0;
  }
}

}  // Game.App.Handlers
