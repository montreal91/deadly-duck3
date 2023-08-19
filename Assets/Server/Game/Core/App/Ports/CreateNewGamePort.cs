
namespace Game.App.Ports {


public interface CreateNewGamePort {
  public void Handle(string gameHandle, int maxSeasons);
}

}  // namespace Game.App.Ports
