using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{	public float health = 150;
	public GameObject RedLaserPrefab;
	public float rateOfFire =10f;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	private ScoreKeeperScript scoreKeeper;
	public AudioClip enemyLaser;
	public AudioClip enemyDies;
	
	void Start()
	{	scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeperScript>();
	}

	void Update()
	{	float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability)
		{	EnemyFireControl();
		}
	}
	
	public void DifficultyManager(int diff)
	{	if(diff % 3 == 0)
		{	shotsPerSecond += 0.2f;
			Debug.Log("Shots per second" + shotsPerSecond);
		}
	}
	
	public void EnemyFireControl()
	{	AudioSource.PlayClipAtPoint(enemyLaser,transform.position);
		Vector3 startPosition = transform.position + new Vector3(0f,-0.45f,0f);
		GameObject EnemyFire = Instantiate(RedLaserPrefab, startPosition, Quaternion.identity) as GameObject;
		//Debug.Log ("Enemy Fire");
		EnemyFire.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-rateOfFire,0);
	}
	
	void OnTriggerEnter2D(Collider2D trigger)
	{	//Debug.Log ("Enemy Hit");
		ProjectileScript missile = trigger.gameObject.GetComponent<ProjectileScript>();
		if(missile)
		{	health -= missile.GetDamage();
			missile.Hit();
			if(health <=0)
			{	AudioSource.PlayClipAtPoint(enemyDies,transform.position,0.5f);
				Destroy(gameObject);
				scoreKeeper.Score(scoreValue);
			}
		}
	}
}