using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationContext : MonoBehaviour {
  private readonly ServerBuilder serverBuilder = new ServerBuilder();

  public ServerBuilder ServerProvider {
    get => serverBuilder;
  }

  void Start() {}

    // Update is called once per frame
  void Update() {}
}
