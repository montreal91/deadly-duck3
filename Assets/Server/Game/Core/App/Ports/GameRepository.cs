using System.Collections.Generic;

namespace Domain.Game {

public interface GameRepository {
  void Save(Game game);
  Game? GetGameByHandle(string handle);
  bool DoesGameExist(string handle);
  IList<Game> GetGames();
}

}  // namespace Domain.Game
