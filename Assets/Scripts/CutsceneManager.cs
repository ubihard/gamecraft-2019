using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Animation anim;
    public int walkTime;

    void Start()
    {
        // Rewind the walk animation
        anim["Magic"].time = walkTime;
    }
}
