
using System.Collections.Generic;

namespace App.Game.Handlers {

public class GetAllGamesQueryImpl : Domain.Game.Queries.GetAllGamesQuery {
  private readonly GameRepository gameRepository;

  public GetAllGamesQueryImpl(GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  IList<Game> Domain.Game.Queries.GetAllGamesQuery.Handle() {
    return gameRepository.GetGames();
  }
}

}  // namespace App.Game.Handlers
