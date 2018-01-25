using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

  GameObject car;
  GameObject flag;
  GameObject distance;

  private const string CAR_OBJECT_NAME = "car";
  private const string FLAG_OBJECT_NAME = "flag";
  private const string DISTANCE_OBJECT_NAME = "Distance";

  private const string TWO_DECIMAL_PLACES = "F2";
  // Use this for initialization
  void Start()
  {
    car = GameObject.Find(CAR_OBJECT_NAME);
    flag = GameObject.Find(FLAG_OBJECT_NAME);
    distance = GameObject.Find(DISTANCE_OBJECT_NAME);
  }

  // Update is called once per frame
  void Update()
  {
    var length = flag.transform.position.x - car.transform.position.x;
    distance.GetComponent<Text>().text = length >= 0
    ? $"ゴールまで{length.ToString(TWO_DECIMAL_PLACES)}m"
    : "ゲームオーバー";
  }
}
