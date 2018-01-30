using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


  private Rigidbody2D rigid2D;
  private const float JUMP_FORCE = 680.0f;
  private const float WALK_FORCE = 30.0f;
  private const float MAX_WALK_SPEED = 2.0f;

  void Start()
  {
    rigid2D = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rigid2D.AddForce(transform.up * JUMP_FORCE);
    }

    var moveCoefficient = GetMoveCoefficient();
    var speedx = Mathf.Abs(rigid2D.velocity.x);
    if (speedx < MAX_WALK_SPEED)
    {
      rigid2D.AddForce(transform.right * moveCoefficient * WALK_FORCE);
    }

    if (moveCoefficient != 0)
    {
      // When inverting, multiply the enlargement ratio of x axis by -1
      var xAxisMultiple = moveCoefficient >= 0 ? 1 : -1;
      transform.localScale = new Vector3(xAxisMultiple, 1, 1);
    }
  }

  /**
	 * get for coefficient of moving.
	 * 
	 * @return coefficient of moving. right: 1, left: -1, non: 0;
	 */
  private int GetMoveCoefficient()
  {
    if (Input.GetKey(KeyCode.RightArrow)) return 1;
    if (Input.GetKey(KeyCode.LeftArrow)) return -1;
    return 0;
  }
}
