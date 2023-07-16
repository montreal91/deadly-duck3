using System.Collections.Generic;

namespace Domain.Game.Port {

public class CreateNewGameCommandImpl : CreateNewGameCommand {
  private readonly GameRepository gameRepository;
  private readonly HashSet<int> GAME_LENGTHS = new HashSet<int>(
    new int[] {5, 10, 25, 50}
  );

  public CreateNewGameCommandImpl(GameRepository gameRepository) {
    this.gameRepository = gameRepository;
  }

  public void Handle(string gameHandle, int maxSeasons) {
    if (gameRepository.DoesGameExist(gameHandle)) {
      // Debug.Log($"[{gameHandle}] game already exists.");
      throw new System.Exception($"[{gameHandle}] game already exists.");
    }

    if (!GAME_LENGTHS.Contains(maxSeasons)) {
      // Debug.Log(
      //   $"Invalid number of seasons. ({maxSeasons}, should be 5, 10, 25, 50)"
      // );
      throw new System.Exception($"Invalid number of seasons. ({maxSeasons}, should be 5, 10, 25, 50)");
      // return;
    }

    Game game = new Game(gameHandle, maxSeasons);
    gameRepository.Save(game);
  }
}

}  // namespace Domain.Game.Port
