
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
  public string canvasTag;
  public string initialCanvas;

  private Dictionary<string, Canvas> canvasHolder = new Dictionary<string, Canvas>();
  void Start(){
    foreach (GameObject canvas in GameObject.FindGameObjectsWithTag(canvasTag)) {
      Debug.Log(canvas.name);
      canvasHolder.Add(canvas.name, canvas.GetComponent<Canvas>());
    }

    ShowCanvas(initialCanvas);
  }

  void Update() {}

  private void DisableAllCanvases() {
    foreach (Canvas canvas in canvasHolder.Values) {
      canvas.enabled = false;
    }
  }

  public void ShowCanvas(string canvasName) {
    if (!canvasHolder.ContainsKey(canvasName)) {
      Debug.Log($"Canvas [{canvasName}] does not exist.");
      return;
    }

    DisableAllCanvases();
    canvasHolder[canvasName].enabled = true;
  }
}
