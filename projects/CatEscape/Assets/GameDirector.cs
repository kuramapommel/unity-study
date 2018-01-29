using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

  GameObject hpGuage;

  private const string HP_GUAGE_OBJECT_NAME = "hpGuage";

  // Use this for initialization
  void Start()
  {
    hpGuage = GameObject.Find(HP_GUAGE_OBJECT_NAME);
  }

  // Update is called once per frame
  public void DecreaseHp()
  {
    hpGuage.GetComponent<Image>().fillAmount -= 0.1f;
  }
}
