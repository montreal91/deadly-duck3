
namespace Domain.Game.Commands {

public interface CreateNewGame {
  public void Handle(string gameHandle, int maxSeasons);
}

}  // namespace Domain.Game.Commands
