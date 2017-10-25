using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizardScript : MonoBehaviour 
{	int max;
	int min;
	int guess;
	int GuessLimit;
	public Text text;
	
	void Start () 
	{	StartGame();
	}
	void StartGame()
	{	max = 1000;
		min = 1;
		GuessLimit = 15;
		NextGuess();
	}
	
	public void Higher()
	{	min	= guess;
		NextGuess();
	}
	
	public void Lower()
	{	max = guess;
		NextGuess();
	}
	
	void NextGuess()
	{	guess = Random.Range(min,max+1);
		text.text = guess.ToString();
		GuessLimit = GuessLimit-1;
		if(GuessLimit <0)
		{	Application.LoadLevel("Win");
		}
	}
}