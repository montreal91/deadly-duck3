using System.Collections.Generic;

namespace Spi.Game {

public class InMemoryGameRepository : Domain.Game.GameRepository {
  private readonly Dictionary<string, Domain.Game.Game> repository;

  public InMemoryGameRepository() {
    this.repository = new Dictionary<string, Domain.Game.Game>();
  }

  public void Save(Domain.Game.Game game) {
    repository[game.Handle] = game;
  }

  public Domain.Game.Game? GetGameByHandle(string handle) {
    if (repository.ContainsKey(handle)) {
      return repository[handle];
    }

    return null;
  }

  public bool DoesGameExist(string handle) {
    return repository.ContainsKey(handle);
  }

  public IList<Domain.Game.Game> GetGames() {
    var res = new List<Domain.Game.Game>();
    return new List<Domain.Game.Game>(repository.Values);
  }
}

}  // namespace Spi.Game
