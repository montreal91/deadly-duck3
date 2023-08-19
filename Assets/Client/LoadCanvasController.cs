
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadCanvasController : MonoBehaviour {
  public GameState state;
  public ApplicationContext context;

  public Button loadLineButtonPrefab;
  public RectTransform content;

  private Protocol.GameServer gameServer;
  private readonly IList<Button> buttonsToDestroy = new List<Button>();

  void Start() {
    gameServer = context.ServerProvider.GameServer;
  }

  void Update() {}

  public void ShowSavedGames() {
    DestroyButtons();
    CreateSavedGamesButtons();
  }

  private void CreateSavedGamesButtons() {
    var games = gameServer.GetGameListViews();
    for (int i = 0; i < games.Count; i++) {
      Button button = Instantiate(
        loadLineButtonPrefab,
        new Vector3(-120f, 55 -35f * i, 0f),
        Quaternion.identity
      );
      button.transform.SetParent(content, false);
      button.GetComponentInChildren<TMP_Text>().text = games[i].title;
      button.GetComponent<HandleHolder>().SetHandle(games[i].title);
      button.onClick.AddListener(delegate {
        state.currentGameTitle = button.GetComponent<HandleHolder>().Handle;
      });

      buttonsToDestroy.Add(button);
    }
  }

  private void DestroyButtons() {
    foreach (var btn in buttonsToDestroy) {
      Destroy(btn.gameObject);
    }

    buttonsToDestroy.Clear();
  }
}
