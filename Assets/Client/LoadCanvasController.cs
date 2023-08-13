using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvasController : MonoBehaviour {
  public GameState state;

  private bool needUpdateGameList;

  void Start() {}

  void Update() {}

  public void ShowSavedGames() {
  }

  public void SetActiveGame(string game) {
    state.title = game;
  }
}
