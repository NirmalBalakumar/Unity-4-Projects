using UnityEngine;
using System.Collections;

public class MusicManagerScript : MonoBehaviour 
{
	public AudioClip[] levelMusicChangeArray;
	private AudioSource music;
	
	void Awake()
	{	DontDestroyOnLoad(gameObject);
		//Debug.Log("Dont Destroy on load: " + name);	
	}
	
	void Start()
	{	music = GetComponent<AudioSource>();
		music.volume = PlayerPrefsManager.GetMasterVolume();
	}	
				
/*	public void LevelMusic(int level)
	{	Debug.Log("LevelMusic" + level);
		music.Stop();
		music.clip = levelMusicChangeArray[level];
		music.loop = true;
		music.Play();
	}	*/
	void OnLevelWasLoaded(int level)
	{	AudioClip thisLevelMusic = levelMusicChangeArray[level];
		//Debug.Log("LevelMusic" + thisLevelMusic);
		if(thisLevelMusic)
		{	music.Stop();
			music.clip = thisLevelMusic;
			music.loop = true;
			music.Play();
		}
	}
	
	public void SetVolume(float volume)
	{
		music.volume = volume;
	}
}