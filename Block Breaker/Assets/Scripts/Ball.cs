using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
        // Lock ball to paddle
        if (!hasStarted) this.transform.position = paddle.transform.position + paddleToBallVector;

        // Wait for mouse press to launch
        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse clicked, launch ball");
            hasStarted = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }

	}
}
