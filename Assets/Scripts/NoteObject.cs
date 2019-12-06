using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, missEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                if (transform.parent.tag == "Special") {
                    Transform special = transform.parent;
                    special.GetChild(0).gameObject.SetActive(false);
                    special.GetChild(1).gameObject.SetActive(false);
                    special.GetChild(2).gameObject.SetActive(false);
                    special.GetChild(3).gameObject.SetActive(false);
                } else
                {
                    gameObject.SetActive(false);
                }

                RhythmManager.instance.NoteHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = false;

            if (gameObject.activeSelf)
            {
                RhythmManager.instance.NoteMiss();
                Instantiate(missEffect, transform.position, hitEffect.transform.rotation);
            }
        }
    }
}
