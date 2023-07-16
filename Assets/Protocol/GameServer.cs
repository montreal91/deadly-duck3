using System.Collections.Generic;

namespace Protocol {

public interface GameServer {
  public IList<Protocol.GameListViewDto> GetGameListViews();
  public void CreateNewGame(CreateNewGameDto game);
}

} // namespace Protocol
