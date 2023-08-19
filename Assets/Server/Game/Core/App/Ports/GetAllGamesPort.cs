
using System.Collections.Generic;


namespace Game.App.Ports {


public class GetAllGamesDto {
  public readonly string handle;

  public GetAllGamesDto(string handle) {
    this.handle = handle;
  }
}

public interface GetAllGamesPort {
  public IList<GetAllGamesDto> Handle();
}

}  // namespace Game.App.Ports
