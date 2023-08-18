
using System.Collections.Generic;

namespace App.Game.Handlers {

public class GetAllGamesQueryHandler : Domain.Game.Queries.GetAllGamesQuery {
  private readonly Domain.Game.GameRepository gameRepository;

  public GetAllGamesQueryHandler(Domain.Game.GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  IList<Domain.Game.Game> Domain.Game.Queries.GetAllGamesQuery.Handle() {
    return gameRepository.GetGames();
  }
}

}  // namespace App.Game.Handlers
