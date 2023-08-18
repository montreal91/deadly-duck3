
using System.Collections.Generic;


namespace App.Game.Ports {


public class GetAllGamesDto {
  public readonly string handle;

  public GetAllGamesDto(string handle) {
    this.handle = handle;
  }
}

public interface GetAllGamesPort {
  public IList<GetAllGamesDto> Handle();
}

}  // namespace App.Game.Ports
