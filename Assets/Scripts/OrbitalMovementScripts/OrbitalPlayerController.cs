using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalPlayerController : MonoBehaviour
{

	public float moveSpeed;
	float jumpForce = 0f;
	public bool onGround = true;

	public GameObject[] projectilePrefab;

	private Vector3 moveDirection;
	
	private StarterAssets.StarterAssetsInputs _input;

	private Animator _animator;

	public GameManager gameManager;


	//Sound and Music
	public AudioClip jumpSound;
	private AudioSource asPlayer;


	void Start()
	{
		_input = GetComponent<StarterAssets.StarterAssetsInputs>();

		_animator = GetComponent<Animator>();
		asPlayer = GetComponent<AudioSource>();


		//gameManager = Find.GetComponent<GameManager>();
		//gameManager = GetComponent<GameManager>();
	}


	void OnCollisionEnter(Collision toucher)
	{
		if (toucher.gameObject.tag == "Terrain")
		{
			jumpForce = 0;
			onGround = true;
			//Debug.Log("on ground");
		}

        if (toucher.gameObject.tag == "SpeedBoost")
        {
            moveSpeed = moveSpeed * 2;
        }	
	}

	void Update()
	{
		float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");
		float moveMagnitude = new Vector3(horizontalMovement, 0, verticalMovement).magnitude;

		if (gameManager.gameOver == true)
        {
			return;
        }

		if (Input.GetKeyDown(KeyCode.F))
		{
			int projectilePrefabIndex = Random.Range(0, projectilePrefab.Length);
			Instantiate(projectilePrefab[projectilePrefabIndex], transform.position, projectilePrefab[projectilePrefabIndex].transform.rotation);

		}

		if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
			jumpForce += 20f;
			asPlayer.PlayOneShot(jumpSound, 1.0f);
			//Debug.Log("we up");
			onGround = false;
        }

			//moveDirection = new Vector3(_input.move.x, 0, _input.move.y).normalized;

		moveDirection = new Vector3(horizontalMovement, jumpForce, verticalMovement).normalized;

		//horizontalMovement = Input.GetAxis("Horizontal");
		//verticalMovement = Input.GetAxis("Vertical");

		//Vector3 jumpMagnitude = new Vector3(0, jumpForce, 0);

		//Debug.Log(moveMagnitude);

		_animator.SetFloat("Speed", moveMagnitude * 4);
		_animator.SetFloat("MotionSpeed", moveMagnitude);
	}

	void FixedUpdate()
	{
		if (gameManager.gameOver == true)
		{
			_animator.SetFloat("Speed", 0);
			_animator.SetFloat("MotionSpeed", 0);
			return;
		}
		
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
		

        //else
        {
			//moveSpeed = 0;
			//GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
		}
	}
}