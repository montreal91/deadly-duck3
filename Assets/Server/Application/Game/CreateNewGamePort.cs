
namespace Application.Game.Ports {

public interface CreateNewGamePort {
  public void Handle(string gameHandle, int maxSeasons);
}

}  // namespace Application.Game.Ports
