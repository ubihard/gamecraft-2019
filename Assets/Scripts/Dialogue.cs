using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    public float typingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            textDisplay.text = "";
        }
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == sentences.Length - 1)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            StopAllCoroutines();
            NextSentence();
        }
    }
}
