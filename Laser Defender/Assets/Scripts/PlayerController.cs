using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	public float speed;
	public float padding = 0.5f;
	public GameObject laserPrefab;
	public float beamSpeed;
	public float time;
	public float repeatRate;
	public float health = 250;
	public AudioClip playerLaser;
	public AudioClip playerDies;
	
	float xmin;
	float xmax;
	
	void	Start()
	{	float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	void Update ()
	{	if(Input.GetKey(KeyCode.LeftArrow))
		{	//transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if( Input.GetKey(KeyCode.RightArrow))
		{	//transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
		if(Input.GetKeyDown(KeyCode.Space))
		{	InvokeRepeating("LaserControl", time, repeatRate);
		}else if(Input.GetKeyUp(KeyCode.Space))
		{	CancelInvoke("LaserControl");
		}
	}
	
	void LaserControl()
	{	//Debug.Log("Player Laser");
		AudioSource.PlayClipAtPoint(playerLaser,transform.position);
		Vector3 offset = new Vector3(0f,0.65f,0f);
		GameObject LaserBeam = Instantiate(laserPrefab,transform.position+offset, Quaternion.identity) as GameObject;
		LaserBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,beamSpeed,0);
	}
	
	void OnTriggerEnter2D(Collider2D trigger)
	{	//Debug.Log("Player Hit");
		ProjectileScript missile = trigger.gameObject.GetComponent<ProjectileScript>();
		if(missile)
		{	health -= missile.GetDamage();
			missile.Hit();
			if(health <=0)
			{	Die();
			}
		}
	}
	
	void Die()
	{	AudioSource.PlayClipAtPoint(playerDies,transform.position);
		Destroy(gameObject);
		LevelManagerScript levelMan = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
		levelMan.LoadLevel("End");	
	}
}