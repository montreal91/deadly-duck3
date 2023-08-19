
namespace Game.Domain.Commands {

public interface CreateNewGame {
  public void Handle(string gameHandle, int maxSeasons);
}

}  // namespace Game.Domain.Commands
