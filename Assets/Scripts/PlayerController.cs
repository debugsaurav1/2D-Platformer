using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] public LayerMask groundLayer;
	[SerializeField] private AudioSource jumpAudio;

	public Transform groundCheck;

	private Rigidbody2D rb_player;
	private BoxCollider2D coll2D;
	private Animator anim;
	private SpriteRenderer sprite;
	private enum MovementState{idle, running, jumping, falling}

	private float moveInput = 0f;

	private void Awake()
	{
		// Get the index of the ground layer by name
		rb_player = GetComponent<Rigidbody2D>();
		coll2D = GetComponent<BoxCollider2D>();	
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}


	private void Update()
	{
		// Handle player movement
		moveInput = Input.GetAxisRaw("Horizontal");
		rb_player.velocity = new Vector2(moveInput * moveSpeed, rb_player.velocity.y);
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			jumpAudio.Play();
			rb_player.velocity = new Vector2(rb_player.velocity.x, jumpForce);
		}
		UpdateAniamtion();
		closeGame();
	}

	private void UpdateAniamtion() 
	{
		MovementState state;
		if (moveInput > 0f)
		{
			state = MovementState.running;
			sprite.flipX = false;
		}
		else if (moveInput < 0f)
		{
			state = MovementState.running;
			sprite.flipX = true;
		}
		else
		{
			state = MovementState.idle;
		}

		if (rb_player.velocity.y > 0.1f) 
		{
			state = MovementState.jumping;
		}
		else if (rb_player.velocity.y < -0.1f)
		{
			state = MovementState.falling;
		}
		anim.SetInteger("state", (int)state);
			
	}
	private bool IsGrounded() 
	{
		return Physics2D.BoxCast(coll2D.bounds.center, coll2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
	}

	//Close the game mid stage
	private void closeGame()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("End");
		}
	}
}
