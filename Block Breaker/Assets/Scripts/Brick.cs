using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public static int breakableCount = 0;
    private LevelManager levelManager;
    private int timesHit;
    public Sprite[] hitSprites;
    private bool isBreakable;
    public GameObject smoke;

    // Use this for initialization
    void Start () {
        isBreakable = this.tag == "Breakable";
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits ()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
            GameObject newSmoke = Instantiate(smoke, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = newSmoke.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<SpriteRenderer>().color;
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Missing sprite");
        }
    }
}
