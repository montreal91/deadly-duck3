
using System.Collections.Generic;

namespace Game.Domain.Queries {


public class GetAllGamesQuery {}

public class QueryGameDto {
  public readonly string handle;

  public QueryGameDto(string handle) {
    this.handle = handle;
  }
}

public class GetAllGamesQueryRes {
  public readonly IList<QueryGameDto> games;

  public GetAllGamesQueryRes(IList<QueryGameDto> games) {
    this.games = games;
  }
}

}  // namespace Game.Domain.Queries
