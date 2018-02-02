using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{

  public GameObject igaguriPrefab;
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      var igaguri = Instantiate(igaguriPrefab) as GameObject;

      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      var worldDir = ray.direction;
      igaguri.GetComponent<IgaguriController>().Short(worldDir.normalized * 2000);
    }
  }
}
