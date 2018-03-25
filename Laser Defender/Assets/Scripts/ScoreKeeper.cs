﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(int points)
    {
        score += points;
        UpdateScore();
    }

    public void Reset()
    {
        score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
