using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Runner : MonoBehaviour {
  public Canvas mainMenuCanvas;
  public Canvas newGameCanvas;
  public Canvas loadGameCanvas;
  public Canvas mainGameCanvas;
  public TMP_InputField gameTitleInput;
  public TMP_Dropdown gameLengthDropdown;
  public TMP_Text mainGameTitle;
  public RectTransform content;
  public Button loadLineButtonPrefab;

  public ApplicationContext context;
  // public CanvasManager canvasManager;

  private readonly int[] INPUT_TO_MAX_SEASONS = new int[]{10, 5, 25, 50};
  // private readonly ServerBuilder serverBuilder = new ServerBuilder();
  private Protocol.GameServer gameServer;
  private string currentGame;
  private readonly IList<Button> buttonsToDestroy = new List<Button>();

  void Start() {
    DisableAllCanvases();
    mainMenuCanvas.enabled = true;
    gameServer = context.ServerProvider.GameServer;
  }

  void Update() {}

  public void ShowStartNewGameScreen() {
    DisableAllCanvases();
    newGameCanvas.enabled = true;

    gameTitleInput.text = "";
    gameLengthDropdown.value = 0;
  }

  public void ShowLoadGameScreen() {
    DisableAllCanvases();
    FillSavedGames();
    loadGameCanvas.enabled = true;
  }

  public void BackToMainMenuScreen() {
    DisableAllCanvases();
    mainMenuCanvas.enabled = true;
    currentGame = "";
  }

  public void StartNewGame() {
    if (gameTitleInput.text.Length < 3) {
      Debug.Log("Game title is too short.");
      return;
    }

    gameServer.CreateNewGame(new Protocol.CreateNewGameDto(
      gameTitleInput.text, INPUT_TO_MAX_SEASONS[gameLengthDropdown.value]
    ));

    ActivateGame(gameTitleInput.text);
  }

  public void Quit() {
    Application.Quit();
  }

  public void LoadSavedGame() {
    ActivateGame(currentGame);
  }

  private void DisableAllCanvases() {
    mainMenuCanvas.enabled = false;
    newGameCanvas.enabled = false;
    loadGameCanvas.enabled = false;
    mainGameCanvas.enabled = false;
    DestroyButtons();
  }

  private void FillSavedGames() {
    var games = gameServer.GetGameListViews();
    for (int i = 0; i < games.Count; i++) {
      Button button = Instantiate(
        loadLineButtonPrefab,
        new Vector3(-120f, 55 -35f * i, 0f),
        Quaternion.identity
      );
      button.transform.SetParent(content, false);
      button.GetComponentInChildren<TMP_Text>().text = games[i].gameTitle;
      button.GetComponent<HandleHolder>().SetHandle(games[i].gameTitle);
      button.onClick.AddListener(delegate {
        currentGame = button.GetComponent<HandleHolder>().Handle;
      });
      buttonsToDestroy.Add(button);
    }
  }

  private void ActivateGame(string game) {
    currentGame = game;
    mainGameTitle.text = currentGame;
    DisableAllCanvases();
    mainGameCanvas.enabled = true;
  }

  private void DestroyButtons() {
    foreach (var btn in buttonsToDestroy) {
      Destroy(btn.gameObject);
    }

    buttonsToDestroy.Clear();
  }
}
