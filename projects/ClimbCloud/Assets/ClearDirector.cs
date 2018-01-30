using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearDirector : MonoBehaviour
{

  private const string GAME_SCENE_NAME = "GameScene";
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      SceneManager.LoadScene(GAME_SCENE_NAME);
    }

  }
}
