
// Hand-crafted hard-coded ApplicationContext
public class ServerBuilder {
  private readonly Domain.Game.GameRepository gameRepository;
  private readonly Domain.Game.Queries.GetAllGamesQuery getAllGamesQuery;
  private readonly Domain.Game.Commands.CreateNewGame createNewGameCommand;
  private readonly Api.Game.Adapters.CreateNewGameAdapter createNewGameAdapter;
  private readonly Api.Game.Adapters.GetAllGamesAdapter getAllGamesAdapter;
  private readonly Api.Game.Adapters.GameToDtoConverter gameToDtoConverter;
  private readonly Api.Game.GameConverter gameConverter;
  private readonly Protocol.GameServer gameController;


  public ServerBuilder() {
    gameRepository = new Spi.Game.InMemoryGameRepository();
    getAllGamesQuery = new App.Game.Handlers.GetAllGamesQueryHandler(
        gameRepository
    );

    createNewGameCommand = new App.Game.Handlers.CreateNewGameCommand(
        gameRepository
    );

    createNewGameAdapter = new  Api.Game.Adapters.CreateNewGameAdapter(
        createNewGameCommand
    );

    gameToDtoConverter = new Api.Game.Adapters.GameToDtoConverter();

    getAllGamesAdapter = new Api.Game.Adapters.GetAllGamesAdapter(
        getAllGamesQuery, gameToDtoConverter
    );

    gameConverter = new Api.Game.GameConverter();
    gameController = new Api.Game.GameController(
      getAllGamesAdapter, createNewGameAdapter, gameConverter
    );
  }

  public Protocol.GameServer GameServer {
    get => gameController;
  }
}
