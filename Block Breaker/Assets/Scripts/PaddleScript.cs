using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour 
{	public bool autoplay = false;
	private BallScript ball;
	
	void Start () 
	{	ball = GameObject.FindObjectOfType<BallScript>();
	}
	
	void Update () 
	{	if(!autoplay)
		{	MoveMouse();
		}else
		{	Autoplay();
		}
	}
	
	void MoveMouse()
	{	Vector3 PaddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		float mousePosInBlocks = Input.mousePosition.x/Screen.width * 16;
		PaddlePos.x = Mathf.Clamp(mousePosInBlocks,0.84f,15.16f);
		this.transform.position = PaddlePos;
	}
	
	void Autoplay()
	{	Vector3 PaddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		Vector3 BallPos = ball.transform.position;
		PaddlePos.x = Mathf.Clamp(BallPos.x,0.84f,15.16f);
		this.transform.position = PaddlePos;	
	}
}