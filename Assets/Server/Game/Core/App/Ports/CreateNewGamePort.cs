
namespace App.Game.Ports {


public interface CreateNewGamePort {
  public void Handle(string gameHandle, int maxSeasons);
}

}  // namespace App.Game.Ports
