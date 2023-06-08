using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	private static Text scoreValue;
    private static int score;
	
	void Awake ()
	{
        scoreValue = GetComponent<Text>();
        score = 0;
	}

    /// <summary>Add point to score.</summary>
    public static void AddPoint()
	{
		score++;
        scoreValue.text = score.ToString();
    }



}
