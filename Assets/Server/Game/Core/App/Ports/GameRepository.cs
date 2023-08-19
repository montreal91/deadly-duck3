using System.Collections.Generic;

namespace Game.App.Ports {

using GameModel = Game.Domain.Model.Game;

public interface GameRepository {
  void Save(GameModel game);
  GameModel? GetGameByHandle(string handle);
  bool DoesGameExist(string handle);
  IList<GameModel> GetGames();
}

}  // namespace Game.App.Ports
