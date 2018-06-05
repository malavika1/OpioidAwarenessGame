using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int pillValue;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}

    void OnTriggerEnter2D ()
    {
        score += pillValue;
        UpdateScore();

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
	
	void UpdateScore()
    {
        scoreText.text = "Score:\n" + score;
    }

    public int GetScore()
    {
        return score;
    }
}
