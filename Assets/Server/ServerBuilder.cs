
// Hand-crafted hard-coded ApplicationContext
public class ServerBuilder {
  private readonly Game.Domain.Queries.GetAllGamesQuery getAllGamesQuery;
  private readonly Game.Domain.Commands.CreateNewGame createNewGameCommand;
  private readonly Game.App.Ports.GameRepository gameRepository;
  private readonly Game.Adapters.CreateNewGameAdapter createNewGameAdapter;
  private readonly Game.Adapters.GetAllGamesAdapter getAllGamesAdapter;
  private readonly Game.Adapters.GameToDtoConverter gameToDtoConverter;
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

    gameToDtoConverter = new Game.Adapters.GameToDtoConverter();

    getAllGamesAdapter = new Game.Adapters.GetAllGamesAdapter(
        getAllGamesQuery, gameToDtoConverter
    );

    gameConverter = new Game.Api.GameConverter();
    gameController = new Game.Api.GameController(
      getAllGamesAdapter, createNewGameAdapter, gameConverter
    );
  }

  public Protocol.GameServer GameServer {
    get => gameController;
  }
}
