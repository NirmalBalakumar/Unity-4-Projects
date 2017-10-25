using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour 
{	public void LoadLevel(string name)
	{	Debug.Log("Level load requested for :"+ name);
		BrickScript.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	public void QuitRequest()
	{	Debug.Log("I want to quit!");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{	BrickScript.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed()
	{	if(BrickScript.breakableCount <=0)
		{	LoadNextLevel();
		}
	}
}