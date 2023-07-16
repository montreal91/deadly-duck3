
using System;

namespace Domain.Game {

public class Game {
  private readonly string handle;
  private readonly int maxSeasons;
  private int currentSeason;
  private readonly DateTime createdAt;
  private DateTime lastUpdatedAt;
  private bool isDeleted;

  public string Handle {
    get => handle;
  }

  public Game(string handle, int maxSeasons) {
    this.handle = handle;
    this.maxSeasons = maxSeasons;
    this.currentSeason = 1;
    this.createdAt = DateTime.Now;
    this.lastUpdatedAt = DateTime.Now;
    this.isDeleted = false;
  }
}

}  // namespace Domain.Game
