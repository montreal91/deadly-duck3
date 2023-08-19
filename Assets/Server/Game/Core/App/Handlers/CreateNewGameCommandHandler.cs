using System.Collections.Generic;


namespace Game.App.Handlers {


public class CreateNewGameCommand : Game.Domain.Commands.CreateNewGame {
  private readonly Game.App.Ports.GameRepository gameRepository;
  private readonly HashSet<int> GAME_LENGTHS = new HashSet<int>(
    new int[] {5, 10, 25, 50}
  );

  public CreateNewGameCommand(Game.App.Ports.GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  void Game.Domain.Commands.CreateNewGame.Handle(
      string gameHandle, int maxSeasons
  ) {
    if (gameRepository.DoesGameExist(gameHandle)) {
      throw new Game.Core.Exceptions.GameCreationException(
        $"[{gameHandle}] game already exists."
      );
    }

    if (!GAME_LENGTHS.Contains(maxSeasons)) {
      throw new Game.Core.Exceptions.GameCreationException(
        $"Invalid number of seasons. ({maxSeasons}, should be 5, 10, 25, 50)"
      );
    }

    var game = new Game.Domain.Model.Game(gameHandle, maxSeasons);
    gameRepository.Save(game);
  }
}

}  // Game.App.Handlers
