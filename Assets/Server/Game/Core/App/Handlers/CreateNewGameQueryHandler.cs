
using System.Collections.Generic;

using Lib;

namespace Game.App.Handlers {

using GetAllGamesQuery = Game.Domain.Queries.GetAllGamesQuery;
using GetAllGamesQueryRes = Game.Domain.Queries.GetAllGamesQueryRes;
using QueryDto = Game.Domain.Queries.QueryGameDto;

public class GetAllGamesQueryHandler :
    QueryHandler<GetAllGamesQuery, GetAllGamesQueryRes> {
  private readonly Game.App.Ports.GameRepository gameRepository;

  public GetAllGamesQueryHandler(Game.App.Ports.GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  public GetAllGamesQueryRes Handle(GetAllGamesQuery query) {
    var games = gameRepository.GetGames();
    var dtos = new List<QueryDto>();

    foreach (var game in games) {
      dtos.Add(new QueryDto(game.Handle));
    }

    return new GetAllGamesQueryRes(dtos);
  }
}

}  // namespace Game.App.Handlers
