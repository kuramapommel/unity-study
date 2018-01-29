using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{

  public GameObject arrowPrefab;
  private const float SPAN = 1.0f;
  private float delta = 0f;

  // Update is called once per frame
  void Update()
  {
    delta += Time.deltaTime;
    if (delta > SPAN)
    {
      delta = 0;
      var arrow = Instantiate(arrowPrefab) as GameObject;
      var px = Random.Range(-6, 7);
      arrow.transform.position = new Vector3(px, 7, 0);
    }
  }
}
