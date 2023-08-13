using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHolder : MonoBehaviour {
  private string handle;

  public string Handle {
    get => handle;
  }

  void Start() {}

  void Update() {}

  public void SetHandle(string handle) {
    this.handle = handle;
  }
}
