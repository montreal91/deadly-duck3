
using System.Collections.Generic;

namespace Domain.Game.Queries {

public interface GetAllGamesQuery {
  IList<Game> Handle();
}

}  // namespace Domain.Game.Queries
