
using System.Collections.Generic;


namespace Game.Adapters {

using GameDto = Game.App.Ports.GetAllGamesDto;


public class GetAllGamesAdapter : Game.App.Ports.GetAllGamesPort {
  private readonly Game.App.Handlers.GetAllGamesQueryHandler getAllGamesQuery;

  public GetAllGamesAdapter(
      Game.App.Handlers.GetAllGamesQueryHandler getAllGamesQuery
  ) {
    this.getAllGamesQuery = getAllGamesQuery;
  }

  IList<GameDto> Game.App.Ports.GetAllGamesPort.Handle() {
    var res = new List<GameDto>();

    foreach (var game in getAllGamesQuery.Handle(null).games) {
      res.Add(new GameDto(game.handle));
    }

    return res;
  }
}

}  // namespace Game.Adapters
