
// Hand-crafted hard-coded ApplicationContext
public class ServerBuilder {
  private readonly Domain.Game.GameRepository gameRepository;
  private readonly Domain.Game.Port.GetAllGamesQuery getAllGamesQuery;
  private readonly Domain.Game.Commands.CreateNewGame createNewGameCommand;
  private readonly Api.Game.Adapters.CreateNewGameAdapter createNewGameAdapter;
  private readonly Api.Game.GameConverter gameConverter;
  private readonly Protocol.GameServer gameController;


  public ServerBuilder() {
    gameRepository = new Spi.Game.InMemoryGameRepository();
    getAllGamesQuery = new Domain.Game.Port.GetAllGamesQueryImpl(
        gameRepository
    );

    createNewGameCommand = new App.Game.Handlers.CreateNewGameCommand(
        gameRepository
    );

    createNewGameAdapter = new  Api.Game.Adapters.CreateNewGameAdapter(
        createNewGameCommand
    );

    gameConverter = new Api.Game.GameConverter();
    gameController = new Api.Game.GameController(
      getAllGamesQuery, createNewGameAdapter, gameConverter
    );
  }

  public Protocol.GameServer GameServer {
    get => gameController;
  }
}
