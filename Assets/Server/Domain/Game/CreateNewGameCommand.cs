
namespace Domain.Game.Port {

public interface CreateNewGameCommand {
  public void Handle(string gameHandle, int maxSeasons);
}

}  // namespace Domain.Game.Port
