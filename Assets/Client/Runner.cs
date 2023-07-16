using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Runner : MonoBehaviour {
    public Canvas mainMenuCanvas;
    public Canvas newGameCanvas;
    public Canvas mainGameCanvas;
    public TMP_InputField gameTitleInput;
    public TMP_Dropdown gameLengthDropdown;
    public TMP_Text mainGameTitle;

    private readonly int[] INPUT_TO_MAX_SEASONS = new int[]{10, 5, 25, 50};

    private readonly ServerBuilder serverBuilder = new ServerBuilder();
    private Protocol.GameServer gameServer;
    private string currentGame;

    void Start() {
        mainMenuCanvas.enabled = true;
        newGameCanvas.enabled = false;
        mainGameCanvas.enabled = false;
        gameServer = serverBuilder.GameServer;
    }

    void Update() {
    }

    public void ShowStartNewGameScreen() {
        mainMenuCanvas.enabled = false;
        newGameCanvas.enabled = true;

        gameTitleInput.text = "";
        gameLengthDropdown.value = 0;
    }

    public void BackToMainMenuScreen() {
        newGameCanvas.enabled = false;
        mainGameCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }

    public void StartNewGame() {
        if (gameTitleInput.text.Length < 3) {
            Debug.Log("Game title is too short.");
            return;
        }

        gameServer.CreateNewGame(new Protocol.CreateNewGameDto(
            gameTitleInput.text, INPUT_TO_MAX_SEASONS[gameLengthDropdown.value]
        ));
        currentGame = gameTitleInput.text;
        mainGameTitle.text = currentGame;
        OpenMainGameScreen();
    }

    public void Quit() {
        Application.Quit();
    }

    private void OpenMainGameScreen() {
        mainMenuCanvas.enabled = false;
        newGameCanvas.enabled = false;
        mainGameCanvas.enabled = true;
    }
}
