using UnityEngine;
using System.Collections;

public class LoseColliderScript : MonoBehaviour 
{	private LevelManagerScript level;

	void OnTriggerEnter2D (Collider2D trigger)
	{	level = GameObject.FindObjectOfType<LevelManagerScript>();
		level.LoadLevel("Lose");
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{	print ("Collision");
	}
}