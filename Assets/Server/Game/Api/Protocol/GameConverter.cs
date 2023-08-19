
namespace Game.Api {

public class GameConverter {
  public Protocol.GameListViewDto ToViewDto(Game.App.Ports.GetAllGamesDto game) {
    return new Protocol.GameListViewDto(game.handle);
  }
}

}  // namespace Game.Api
