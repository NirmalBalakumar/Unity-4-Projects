using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour 
{	public float autoLoadNextLevelAfter;
	//public MusicManagerScript musicManger;
	
	void Start()
	{	if(autoLoadNextLevelAfter >0)
		{	Invoke("LoadNextLevel", autoLoadNextLevelAfter);	
		}else
		{	 //Debug.Log("AutolLoadLevel disabled");
		}
	}

	public void LoadLevel(string name)
	{	Debug.Log("Level load requested for :"+ name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest()
	{	Debug.Log("I want to quit!");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{	int nextLevel = Application.loadedLevel + 1;
		Application.LoadLevel(nextLevel);
		//musicManger.LevelMusic(nextLevel);
	}
}