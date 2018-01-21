using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{

  /** rotational speed */
  private float rotSpeed = 0;

  void Start()
  {

  }

  void Update()
  {
    // set rotSpeed when mouse click.
    if (Input.GetMouseButtonDown(0))
    {
      rotSpeed = 10;
    }

    // revolve roulette.
    transform.Rotate(0, 0, rotSpeed);

    rotSpeed *= 0.96f;
  }
}
