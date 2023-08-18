
using System.Collections.Generic;


namespace Api.Game.Adapters {

using GameDto = App.Game.Ports.GetAllGamesDto;

public class GameToDtoConverter {
  public GameDto Convert(Domain.Game.Game game) {
    return new GameDto(game.Handle);
  }
}

public class GetAllGamesAdapter : App.Game.Ports.GetAllGamesPort {
  private Domain.Game.Queries.GetAllGamesQuery getAllGamesQuery;
  private GameToDtoConverter converter;

  public GetAllGamesAdapter(
      Domain.Game.Queries.GetAllGamesQuery getAllGamesQuery,
      GameToDtoConverter converter
  ) {
    this.getAllGamesQuery = getAllGamesQuery;
    this.converter = converter;
  }

  IList<GameDto> App.Game.Ports.GetAllGamesPort.Handle() {
    var res = new List<GameDto>();

    foreach (var game in getAllGamesQuery.Handle()) {
      res.Add(converter.Convert(game));
    }

    return res;
  }
}

}  // namespace Api.Game.Adapters
