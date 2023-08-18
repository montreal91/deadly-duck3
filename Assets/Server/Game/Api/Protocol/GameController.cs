
using System.Collections.Generic;

namespace Api.Game {


public class GameController : Protocol.GameServer {
  private readonly App.Game.Ports.GetAllGamesPort getAllGamesPort;
  private readonly App.Game.Ports.CreateNewGamePort createNewGamePort;
  private readonly GameConverter gameConverter;

  public GameController(
      App.Game.Ports.GetAllGamesPort getAllGamesPort,
      App.Game.Ports.CreateNewGamePort createNewGamePort,
      GameConverter gameConverter
  ) {
    this.getAllGamesPort = getAllGamesPort;
    this.createNewGamePort = createNewGamePort;
    this.gameConverter = gameConverter;
  }

  IList<Protocol.GameListViewDto> Protocol.GameServer.GetGameListViews() {
    var games = new List<Protocol.GameListViewDto>();

    foreach(var gameDto in getAllGamesPort.Handle()) {
      games.Add(gameConverter.ToViewDto(gameDto));
    }

    return games;
  }

  void Protocol.GameServer.CreateNewGame(Protocol.CreateNewGameDto game) {
    createNewGamePort.Handle(game.gameTitle, game.maxSeasons);
  }
}

}  // namespace Api.Game
