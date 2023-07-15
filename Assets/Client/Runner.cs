using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Runner : MonoBehaviour {
    public Canvas mainMenuCanvas;
    public Canvas newGameCanvas;

    void Start() {
        mainMenuCanvas.enabled = true;
        newGameCanvas.enabled = false;
    }

    void Update() {
    }

    public void StartNewGame() {
        mainMenuCanvas.enabled = false;
        newGameCanvas.enabled = true;
    }

    public void BackToMainMenu() {
        newGameCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }

    public void Quit() {
        Application.Quit();
    }
}
