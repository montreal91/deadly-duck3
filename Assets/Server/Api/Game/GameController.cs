using System.Collections.Generic;

namespace Api.Game {


public class GameController : Protocol.GameServer {
  private readonly Domain.Game.Port.GetAllGamesQuery getAllGamesQuery;
  private readonly App.Game.Ports.CreateNewGamePort createNewGamePort;
  private readonly GameConverter gameConverter;

  public GameController(
      Domain.Game.Port.GetAllGamesQuery getAllGamesQuery,
      App.Game.Ports.CreateNewGamePort createNewGamePort,
      GameConverter gameConverter
  ) {
    this.getAllGamesQuery = getAllGamesQuery;
    this.createNewGamePort = createNewGamePort;
    this.gameConverter = gameConverter;
  }

  IList<Protocol.GameListViewDto> Protocol.GameServer.GetGameListViews() {
    var games = new List<Protocol.GameListViewDto>();

    foreach(var game in getAllGamesQuery.Handle()) {
      games.Add(gameConverter.ToViewDto(game));
    }

    return games;
  }

  void Protocol.GameServer.CreateNewGame(Protocol.CreateNewGameDto game) {
    createNewGamePort.Handle(game.gameTitle, game.maxSeasons);
  }
}

}  // namespace Api.Game
