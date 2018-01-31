using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


  private Rigidbody2D rigid2D;
  private Animator animator;
  private const float JUMP_FORCE = 680.0f;
  private const float WALK_FORCE = 30.0f;
  private const float MAX_WALK_SPEED = 2.0f;

  private const float THRESHOLD = 0.2f;

  private const string CLEAR_SCENE_NAME = "ClearScene";
  private const string GAME_SCENE_NAME = "GameScene";

  private const string JUMP_TRIGGER_NAME = "JumpTrigger";

  void Start()
  {
    rigid2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (transform.position.y < -10)
    {
      SceneManager.LoadScene(GAME_SCENE_NAME);

    }
    // when player is on the cloud and pushed space key, player could jump.
    if (Input.GetMouseButtonDown(0) && rigid2D.velocity.y == 0)
    {
      animator.SetTrigger(JUMP_TRIGGER_NAME);
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
      // when inverting, multiply the enlargement ratio of x axis by -1
      var xAxisMultiple = moveCoefficient >= 0 ? 1 : -1;
      transform.localScale = new Vector3(xAxisMultiple, 1, 1);
    }

    animator.speed = rigid2D.velocity.y == 0 ? speedx / 2.0f : 1.0f;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("GOAL!!");
    SceneManager.LoadScene(CLEAR_SCENE_NAME);

  }

  /**
	 * get for coefficient of moving.
	 * 
	 * @return coefficient of moving. right: 1, left: -1, non: 0;
	 */
  private int GetMoveCoefficient()
  {
    var accelerationX = Input.acceleration.x;
    if (accelerationX > THRESHOLD) return 1;
    if (accelerationX < -THRESHOLD) return -1;
    return 0;
  }
}
