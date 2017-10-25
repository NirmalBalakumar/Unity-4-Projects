using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour 
{	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private bool isBreakable;
	private int timesHit;
	private LevelManagerScript levelManager;
	
	void Start ()
	{	isBreakable = (this.tag == "Breakable");
		if(isBreakable)
		{	breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
	}
	
	void Update ()
	{	
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{	AudioSource.PlayClipAtPoint (crack, transform.position,0.10f);
		bool isBreakable = (this.tag == "Breakable");
		if(isBreakable)
		{	HandleHits();
		}
	}
	
	void HandleHits()
	{	timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits)
		{	breakableCount--;
			levelManager.BrickDestroyed();
			SmokePuff();
			Destroy(gameObject);
		}
		else
		{	LoadSprites();
		}
	}
	
	void SmokePuff()
	{	GameObject smokepuff = Instantiate(smoke,transform.position, Quaternion.identity) as GameObject;
		smokepuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{	int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex])
		{	this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else
		{ Debug.LogError("Sprite Missing");
		}
	}
	
	//TODO remove the simulate method once we can actually win
	
	void SimulateWin ()
	{	levelManager.LoadNextLevel();
	}
}