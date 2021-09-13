using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class levelSelector : MonoBehaviour
{
    public TextMeshProUGUI levelSelcted;
    public string levelPlatformer = "Platformer";
    public string levelBasic = "Basic";
    public string levelJungle = "Jungle";
    public static string levelToStart = null;
    /* Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }
    */
    public void platformerSelected()
    {
        levelSelcted.text = levelPlatformer;
    }
    public void basicSelected()
    {
        levelSelcted.text = levelBasic;
    }
    public void cancelLevel()
    {
        levelSelcted.text = null;
    }
    public void jungleSelected()
    {
        levelSelcted.text = levelJungle;
    }
    public void toNext()
    {
        SceneManager.LoadScene("PlayerSelection");
        levelToStart = levelSelcted.text;
    }
}
