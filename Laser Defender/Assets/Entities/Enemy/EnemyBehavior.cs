using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour {
    public float health = 150;
    public float shotsPerSecond = 0.5f;
    public GameObject projectile;
    public float projectileSpeed = 10f;
    public AudioClip fireSound;
    public AudioClip deathSound;

    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            health -= projectile.GetDamage();
            if (health <= 0)
            {
                scoreKeeper.Score(scoreValue);
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                Destroy(gameObject);
            }
            projectile.Hit();
        }
    }

    void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
