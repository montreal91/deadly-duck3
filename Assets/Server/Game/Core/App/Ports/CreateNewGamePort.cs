
namespace Game.App.Ports {


public class CreateNewGameDto {
  public readonly string gameHandle;
  public readonly int maxSeasons;

  public CreateNewGameDto(string gameHandle, int maxSeasons) {
    this.gameHandle = gameHandle;
    this.maxSeasons = maxSeasons;
  }
}

public interface CreateNewGamePort {
  public void Handle(CreateNewGameDto dto);
}

}  // namespace Game.App.Ports
