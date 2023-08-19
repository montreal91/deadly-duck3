
// Hand-crafted hard-coded ApplicationContext
public class ServerBuilder {
  private readonly Game.App.Handlers.GetAllGamesQueryHandler getAllGamesQuery;
  private readonly Game.App.Handlers.CreateNewGameCommand createNewGameCommand;
  private readonly Game.App.Ports.GameRepository gameRepository;
  private readonly Game.Adapters.CreateNewGameAdapter createNewGameAdapter;
  private readonly Game.Adapters.GetAllGamesAdapter getAllGamesAdapter;
  private readonly Game.Api.GameConverter gameConverter;
  private readonly Protocol.GameServer gameController;


  public ServerBuilder() {
    gameRepository = new Game.Spi.InMemoryGameRepository();
    getAllGamesQuery = new Game.App.Handlers.GetAllGamesQueryHandler(
        gameRepository
    );

    createNewGameCommand = new Game.App.Handlers.CreateNewGameCommand(
        gameRepository
    );

    createNewGameAdapter = new Game.Adapters.CreateNewGameAdapter(
        createNewGameCommand
    );

    getAllGamesAdapter = new Game.Adapters.GetAllGamesAdapter(getAllGamesQuery);

    gameConverter = new Game.Api.GameConverter();
    gameController = new Game.Api.GameController(
      getAllGamesAdapter, createNewGameAdapter, gameConverter
    );
  }

  public Protocol.GameServer GameServer {
    get => gameController;
  }
}
