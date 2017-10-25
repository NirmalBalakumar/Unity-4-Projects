using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour 
{	private PaddleScript paddle;
	private bool HasStarted = false;
	private Vector3 PaddleBallVector;

	void Start () 
	{	paddle = GameObject.FindObjectOfType<PaddleScript>();
		PaddleBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update () 
	{	if(!HasStarted)
		this.transform.position = paddle.transform.position + PaddleBallVector;
	
		if (Input.GetMouseButtonDown(0))
		{	Debug.Log("Pressed left click.");
			HasStarted = true;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f , 10f);
		}	
	}
	void OnCollisionEnter2D (Collision2D col)
	{	if(HasStarted)
		{	GetComponent<AudioSource>().Play();
			Vector2 tweak = new Vector2 (Random.Range(0f,0.2f), Random.Range(0f,0.2f));
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}