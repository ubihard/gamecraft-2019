using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    public AudioSource music;

    public BeatScroller beatScroller;

    public static RhythmManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        beatScroller.hasStarted = true;

        music.Play();
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
