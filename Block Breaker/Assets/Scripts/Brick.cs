using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private LevelManager levelManager;
    public int maxHits;
    private int timesHit;
    public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void Win()
    {
        levelManager.LoadNextLevel();
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
