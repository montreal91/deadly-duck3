
using System.Collections.Generic;

namespace Game.Domain.Queries {

public interface GetAllGamesQuery {
  IList<Game.Domain.Model.Game> Handle();
}

}  // namespace Game.Domain.Queries
