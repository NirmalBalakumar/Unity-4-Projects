using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeperScript : MonoBehaviour
{	public  Text myText;
	public static int score = 0;

	void Start()
	{	myText = GetComponent<Text>();
		myText.text = score.ToString();
		Reset();
	}
	
	public void Score(int points)
	{	score += points;
		myText.text = score.ToString();
		Debug.Log("+1points");
	}
	
	public static void Reset()
	{	score = 0;
		Debug.Log("Reset");
	}
}