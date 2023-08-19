
namespace Game.Api {

using GetAllGamesDto = Game.App.Ports.GetAllGamesDto;

public class GameConverter {
  public Protocol.GameListViewDto ToViewDto(GetAllGamesDto game) {
    return new Protocol.GameListViewDto(game.handle);
  }
}

}  // namespace Game.Api
