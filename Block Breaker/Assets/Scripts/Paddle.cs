using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float minX;
    public float maxX;
    public bool autoPlay = false;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y);
        float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, minX, maxX);

        paddlePos.x = mousePosInBlocks;

        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y);
        Vector3 ballPos = ball.transform.position;
    
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);

        this.transform.position = paddlePos;
    }
}
