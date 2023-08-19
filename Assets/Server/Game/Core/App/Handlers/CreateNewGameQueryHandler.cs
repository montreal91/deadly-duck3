
using System.Collections.Generic;

namespace Game.App.Handlers {

public class GetAllGamesQueryHandler : Game.Domain.Queries.GetAllGamesQuery {
  private readonly Game.App.Ports.GameRepository gameRepository;

  public GetAllGamesQueryHandler(Game.App.Ports.GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  IList<Game.Domain.Model.Game> Game.Domain.Queries.GetAllGamesQuery.Handle() {
    return gameRepository.GetGames();
  }
}

}  // namespace Game.App.Handlers
