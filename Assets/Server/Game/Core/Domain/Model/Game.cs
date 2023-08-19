
using System;
using System.Collections.Generic;

namespace Game.Domain.Model {

public class Game {
  public static readonly HashSet<int> GAME_LENGTHS = new HashSet<int>(
    new int[] {5, 10, 25, 50}
  );

  private readonly string handle;
  private readonly int maxSeasons;
  private int currentSeason;
  private readonly DateTime createdAt;
  private DateTime lastUpdatedAt;
  private bool isDeleted;

  public string Handle {
    get => handle;
  }

  public int MaxSeasons {
    get => maxSeasons;
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

}  // namespace Game.Domain.Model
