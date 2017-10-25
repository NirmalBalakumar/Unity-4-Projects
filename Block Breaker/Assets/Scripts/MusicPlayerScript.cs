using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour 
{	static MusicPlayerScript instance = null;

	void Awake ()
	{	Debug.Log ("Music Player Awake" + GetInstanceID());
	
		if(	instance != null)
		{	Destroy(gameObject);
			print ("duplicate music player destoyed");
		}
		else
		{	instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start () 
	{	Debug.Log ("Music Player Start" + GetInstanceID());
	}
	void Update () 
	{
	
	}
}
