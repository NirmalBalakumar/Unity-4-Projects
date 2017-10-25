using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public bool moveRight = true;
	public float speed = 5f;
	public float spawnDelay = 0.5f;
	public int waveCount = 0;
	private EnemyBehaviour enemyBehaviour;
	float xmin;
	float xmax;
	

	void Start () 
	{	SpawnUntilFull();
	  //Debug.Log (GameObject.Find("EnemyFormation"));
		//Debug.Log (GameObject.Find("EnemyBlack1"));
		enemyBehaviour = enemyPrefab.GetComponent<EnemyBehaviour>();
		//Debug.Log (enemyBehaviour.EnemyFireControl
				
								
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		xmin = leftmost.x;
		xmax = rightmost.x;
	}
	/*
	void SpawnEnemies()
	{	foreach(Transform child in transform)
		{	GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}	
	}
*/	
	void SpawnUntilFull()
	{	Transform freePosition = NextFreePosition();
		if(freePosition)
		{	GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition())
		{	Invoke("SpawnUntilFull", spawnDelay);
		}
	}
	
	public void OnDrawGizmos()
	{	Gizmos.DrawWireCube(transform.position, new Vector3( width,height));
	}
		
	void Update ()
	{	if(moveRight)
		{	transform.position += Vector3.right *speed*Time.deltaTime;
		}else
		{ 	transform.position += Vector3.left *speed*Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if(leftEdgeOfFormation < xmin)
		{	moveRight = true;
		}else if (rightEdgeOfFormation > xmax)
		{	moveRight = false;
		}
		if(AllMembersDead())
		{	Debug.Log("No Ememies");
			SpawnUntilFull();
			waveCount++;
			enemyBehaviour.DifficultyManager(waveCount);
			Debug.Log("wave" + waveCount);
		}
	}
	
	Transform NextFreePosition()
	{	foreach(Transform childPositionGameObject in transform)
		{	if(childPositionGameObject.childCount == 0)
			{	return childPositionGameObject;
			}
		}
		return null;
	}
	
	bool AllMembersDead()
	{	foreach(Transform childPositionGameObject in transform)
		{	if(childPositionGameObject.childCount > 0)
			{	return false;
			}
		}
		return true;
	}
}