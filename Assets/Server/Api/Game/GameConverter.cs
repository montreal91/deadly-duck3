
namespace Api.Game {

public class GameConverter {
  public Protocol.GameListViewDto ToViewDto(App.Game.Ports.GetAllGamesDto game) {
    return new Protocol.GameListViewDto(game.handle);
  }
}

}  // namespace Api.Game
