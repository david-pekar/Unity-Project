using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class PlayerSelector : MonoBehaviour
{
    public int count = 0;
    public  static GameObject player1;
    public  static GameObject player2;
    public  GameObject User1;
    public  GameObject User2;
    public  GameObject User3;
    public  TextMeshProUGUI Player1Text;
    public  TextMeshProUGUI Player2Text;
    public string us1 = "Knight";
    public string us2 = "Barbarian";
    public string us3 = "Runner";
    public Button knightButton;
    public Button barbarianButton;
    public Button runnerButton;
    
    public Canvas canvas1;
    public Canvas basicCanvas;
    public Canvas platformerCanvas;
    public Canvas jungleCanvas;
   
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
    public void knightSelected()
    {
        if(count == 0)
        {
            player1 = User1;
            count++;
            Player1Text.text = us1;
            knightButton.enabled = false;

        }else if(count == 1)
        {
            player2 = User1;
            count++;
            Player2Text.text = us1;
        }
    }
    public void barbarianSelected()
    {
        if (count == 0)
        {
            player1 = User2;
            count++;
            Player1Text.text = us2;
            barbarianButton.enabled = false;

        } else if (count == 1)
        {
            player2 = User2;
            count++;
            Player2Text.text = us2;
        }
    }
    public void runnerSelected()
    {
        if(count == 0)
        {
            player1 = User3;
            count++;
            Player1Text.text = us3;
            runnerButton.enabled = false;

        }else if(count == 1)
        {
            player2 = User3;
            count++;
            Player2Text.text = us3;
        }
    }
    public void toCancel()
    {
        count = 0;
        Player1Text.text = null;
        Player2Text.text = null;
        runnerButton.enabled = true;
        barbarianButton.enabled = true;
        knightButton.enabled = true;
    }
    public void toStart()
    {
        if(Player1Text != null && Player2Text != null)
        {
            if (levelSelector.levelToStart == "Basic")
            {
                canvas1.gameObject.SetActive(false);
                basicCanvas.gameObject.SetActive(true);
            }else if(levelSelector.levelToStart == "Platformer")
            {
                canvas1.gameObject.SetActive(false);
                platformerCanvas.gameObject.SetActive(true);
            }else if(levelSelector.levelToStart == "Jungle")
            {
                canvas1.gameObject.SetActive(false);
                jungleCanvas.gameObject.SetActive(true);
            }
            

            Instantiate(player1, new Vector3(-5.05f, -3.57f, 0), Quaternion.identity);
            Instantiate(player2, new Vector3(4.89f, -3.47f, 0), Quaternion.identity);


        }
    }
    public void backToLevel()
    {
        SceneManager.LoadScene("Level Selector");
    }
   

}
