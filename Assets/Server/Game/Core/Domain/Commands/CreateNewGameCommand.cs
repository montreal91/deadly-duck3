
namespace Game.Domain.Commands {

public class CreateNewGame {
  public readonly string gameHandle;
  public readonly int maxSeasons;

  public CreateNewGame(string gameHandle, int maxSeasons) {
    this.gameHandle = gameHandle;
    this.maxSeasons = maxSeasons;
  }
}

}  // namespace Game.Domain.Commands
