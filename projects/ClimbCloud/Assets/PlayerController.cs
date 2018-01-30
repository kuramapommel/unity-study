using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


  private Rigidbody2D rigid2D;
  private const float JUMP_FORCE = 680.0f;
  private const float WALK_FORCE = 30.0f;
  private const float MAX_WALK_SPEED = 2.0f;
  // Use this for initialization
  void Start()
  {
    rigid2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rigid2D.AddForce(transform.up * JUMP_FORCE);
    }

    var speedx = Mathf.Abs(rigid2D.velocity.x);

    if (speedx < MAX_WALK_SPEED)
    {
      rigid2D.AddForce(transform.right * GetInput() * WALK_FORCE);
    }
  }

  private int GetInput()
  {
    if (Input.GetKey(KeyCode.RightArrow)) return 1;
    if (Input.GetKey(KeyCode.LeftArrow)) return -1;
    return 0;
  }
}
