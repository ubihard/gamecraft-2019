using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnStart);
    }

    void OnStart()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
