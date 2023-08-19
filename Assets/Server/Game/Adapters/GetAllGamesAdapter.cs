
using System.Collections.Generic;


namespace Game.Adapters {

using GameDto = Game.App.Ports.GetAllGamesDto;

public class GameToDtoConverter {
  public GameDto Convert(Game.Domain.Model.Game game) {
    return new GameDto(game.Handle);
  }
}

public class GetAllGamesAdapter : Game.App.Ports.GetAllGamesPort {
  private Game.Domain.Queries.GetAllGamesQuery getAllGamesQuery;
  private GameToDtoConverter converter;

  public GetAllGamesAdapter(
      Game.Domain.Queries.GetAllGamesQuery getAllGamesQuery,
      GameToDtoConverter converter
  ) {
    this.getAllGamesQuery = getAllGamesQuery;
    this.converter = converter;
  }

  IList<GameDto> Game.App.Ports.GetAllGamesPort.Handle() {
    var res = new List<GameDto>();

    foreach (var game in getAllGamesQuery.Handle()) {
      res.Add(converter.Convert(game));
    }

    return res;
  }
}

}  // namespace Game.Adapters
