using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{

  void OnCollisionEnter(Collision other)
  {
    GetComponent<Rigidbody>().isKinematic = true;
    GetComponent<ParticleSystem>().Play();
  }

  public void Short(Vector3 dir)
  {
    GetComponent<Rigidbody>().AddForce(dir);
  }
}
