using System.Collections.Generic;

namespace Api.Game {

public class GameController : Protocol.GameServer {
  private readonly Domain.Game.Port.GetAllGamesQuery getAllGamesQuery;
  private readonly Domain.Game.Port.CreateNewGameCommand createNewGameCommand;
  private readonly GameConverter gameConverter;

  public GameController(
      Domain.Game.Port.GetAllGamesQuery getAllGamesQuery,
      Domain.Game.Port.CreateNewGameCommand createNewGameCommand,
      GameConverter gameConverter
  ) {
    this.getAllGamesQuery = getAllGamesQuery;
    this.createNewGameCommand = createNewGameCommand;
    this.gameConverter = gameConverter;
  }

  public IList<Protocol.GameListViewDto> GetGameListViews() {
    var games = new List<Protocol.GameListViewDto>();

    foreach(var game in getAllGamesQuery.Handle()) {
      games.Add(gameConverter.ToViewDto(game));
    }

    return games;
  }

  public void CreateNewGame(Protocol.CreateNewGameDto game) {
    createNewGameCommand.Handle(game.gameTitle, game.maxSeasons);
  }
}

}  // namespace Api.Game
