using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

  float speed = 0;
  Vector2 startPos;
  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      startPos = Input.mousePosition;
    }
    else if (Input.GetMouseButtonUp(0))
    {
      var endPos = Input.mousePosition;
      var swipeLength = endPos.x - startPos.x;

      speed = swipeLength / 500.0f;
    }

    transform.Translate(speed, 0, 0);
    speed *= 0.98f;
  }
}
