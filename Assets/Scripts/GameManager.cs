using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startPlaying;

    public BeatScroller beatScroller;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";  
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMiss()
    {
        Debug.Log("Miss");
    }
}
