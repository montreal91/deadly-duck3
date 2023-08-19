using System.Collections.Generic;

namespace Game.Spi {

using GameModel = Game.Domain.Model.Game;
using GameRepository = Game.App.Ports.GameRepository;

public class InMemoryGameRepository : GameRepository {
  private readonly Dictionary<string, GameModel> repository;

  public InMemoryGameRepository() {
    this.repository = new Dictionary<string, GameModel>();
  }

  void GameRepository.Save(GameModel game) {
    repository[game.Handle] = game;
  }

  GameModel? GameRepository.GetGameByHandle(string handle) {
    if (repository.ContainsKey(handle)) {
      return repository[handle];
    }

    return null;
  }

  bool GameRepository.DoesGameExist(string handle) {
    return repository.ContainsKey(handle);
  }

  IList<GameModel> GameRepository.GetGames() {
    var res = new List<GameModel>();
    return new List<GameModel>(repository.Values);
  }
}

}  // namespace Game.Spi
