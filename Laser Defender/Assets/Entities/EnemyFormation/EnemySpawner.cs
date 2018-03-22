using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    private bool movingRight = true;
    public float speed = 5f;

    private float xmin;
    private float xmax;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }

        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftBoundary.x;
        xmax = rightBoundary.x;
    }
	
	// Update is called once per frame
	void Update () {
        float rightEdgeOfFormation = transform.position.x + width * 0.5f;
        float leftEdgeOfFormation = transform.position.x - width * 0.5f;
        if (rightEdgeOfFormation >= xmax)
        {
            movingRight = false;
        }
        else if(leftEdgeOfFormation <= xmin)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }


    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
