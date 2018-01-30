using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

  private GameObject player;
  private const string PLAYER_OBJECT_NAME = "cat";
  void Start()
  {
    player = GameObject.Find(PLAYER_OBJECT_NAME);
  }

  // Update is called once per frame
  void Update()
  {
    var palyerPos = player.transform.position;
    transform.position = new Vector3(transform.position.x, palyerPos.y, transform.position.z);
  }
}
