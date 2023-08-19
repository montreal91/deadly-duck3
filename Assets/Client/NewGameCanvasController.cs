
using TMPro;
using UnityEngine;

public class NewGameCanvasController : MonoBehaviour {
  private static readonly int[] INPUT_TO_MAX_SEASONS = new int[]{10, 5, 25, 50};

  public GameState state;
  public ApplicationContext context;

  private Protocol.GameServer gameServer;

  public TMP_InputField gameTitleInput;
  public TMP_Dropdown gameLengthDropdown;

  void Start() {
    gameServer = context.ServerProvider.GameServer;
  }

  void Update() {}

  public void StartNewGame() {
    if (gameTitleInput.text.Length < 3) {
      Debug.Log("Game title is too short.");
      return;
    }

    gameServer.CreateNewGame(new Protocol.CreateNewGameDto(
      gameTitleInput.text, INPUT_TO_MAX_SEASONS[gameLengthDropdown.value]
    ));

    state.currentGameTitle = gameTitleInput.text;

    gameTitleInput.text = "";
    gameLengthDropdown.value = 0;
  }
}
