
namespace Protocol {

public class CreateNewGameDto {
  public readonly string gameTitle;
  public readonly int maxSeasons;

  public CreateNewGameDto(string gameTitle, int maxSeasons) {
    this.gameTitle = gameTitle;
    this.maxSeasons = maxSeasons;
  }
}

}  // namespace Protocol
