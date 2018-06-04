using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] levelMusicChangeArray;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) { 
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;

            audioSource.Play();
        }
    }
}
