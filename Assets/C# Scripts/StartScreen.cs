using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void aboutButton()
    {
        SceneManager.LoadScene("AboutPage");
    }
  
}
