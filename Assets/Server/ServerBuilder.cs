
// Hand-crafted hard-coded ApplicationContext
public class ServerBuilder {
  private readonly Domain.Game.GameRepository gameRepository;
  private readonly Domain.Game.Port.GetAllGamesQuery getAllGamesQuery;
  private readonly Domain.Game.Port.CreateNewGameCommand createNewGameCommand;
  private readonly Api.Game.GameConverter gameConverter;
  private readonly Protocol.GameServer gameController;


  public ServerBuilder() {
    gameRepository = new Spi.Game.InMemoryGameRepository();
    getAllGamesQuery = new Domain.Game.Port.GetAllGamesQueryImpl(gameRepository);
    createNewGameCommand = new Domain.Game.Port.CreateNewGameCommandImpl(gameRepository);
    gameConverter = new Api.Game.GameConverter();
    gameController = new Api.Game.GameController(
      getAllGamesQuery, createNewGameCommand, gameConverter
    );
  }

  public Protocol.GameServer GameServer {
    get => gameController;
  }
}
