
using System.Collections.Generic;

namespace Domain.Game.Port {

public interface GetAllGamesQuery {
  IList<Game> Handle();
}

}  // namespace Domain.Game
