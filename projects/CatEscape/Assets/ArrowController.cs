using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

  GameObject player;
  private const string PLAYER_OBJECT_NAME = "player";
  private const string GAME_DIRECTOR_OBJECT_NAME = "GameDirector";
  // Use this for initialization
  void Start()
  {
    player = GameObject.Find(PLAYER_OBJECT_NAME);
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(0, -0.1f, 0);

    if (transform.position.y < -5.0f)
    {
      Destroy(gameObject);
    }

    var p1 = transform.position;
    var p2 = player.transform.position;
    var dir = p1 - p2;
    var d = dir.magnitude;
    var r1 = 0.5f;
    var r2 = 1.0f;

    if (d < r1 + r2)
    {
      var director = GameObject.Find(GAME_DIRECTOR_OBJECT_NAME);
      director.GetComponent<GameDirector>().DecreaseHp();

      Destroy(gameObject);
    }
  }
}
