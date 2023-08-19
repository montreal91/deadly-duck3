
using TMPro;
using UnityEngine;

public class MainGameCanvasController : MonoBehaviour {
  public GameState gameState;
  public TMP_Text mainGameTitle;

  void Start() {}

  void Update() {}

  public void UpdateScreenWidgets() {
    mainGameTitle.text = gameState.currentGameTitle;
  }
}
