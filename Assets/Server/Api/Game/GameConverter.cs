
namespace Api.Game {

public class GameConverter {
  public Protocol.GameListViewDto ToViewDto(Domain.Game.Game game) {
    return new Protocol.GameListViewDto(game.Handle);
  }
}

}  // namespace Api.Game
