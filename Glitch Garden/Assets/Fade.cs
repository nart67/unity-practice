using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    private Image image;
    public float fadeInTime;
    private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        Debug.Log(currentColor.a);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            currentColor.a = currentColor.a - (Time.deltaTime / fadeInTime);
            image.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
