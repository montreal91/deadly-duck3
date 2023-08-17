
using System.Collections.Generic;


namespace App.Game.Ports {


// public record Person(string FirstName, string LastName);

public class GetAllGamesDto {
  public readonly string gameHandle;

  public GetAllGamesDto(string gameHandle) {
    this.gameHandle = gameHandle;
  }
}

public interface CreateNewGamePort {
  public IList<GetAllGamesDto> Handle();
}

}  // namespace App.Game.Ports
