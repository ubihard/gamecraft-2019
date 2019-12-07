using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    public AudioSource music;

    public BeatScroller beatScroller;

    public static RhythmManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        beatScroller.hasStarted = true;

        music.Play();
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
    }

    public void NoteMiss()
    {
        Debug.Log("Miss");
    }
}
