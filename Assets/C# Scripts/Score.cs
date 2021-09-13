using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Player1;
    public TextMeshProUGUI Player2;
    public TextMeshProUGUI Player1Health;
    public TextMeshProUGUI Player2Health;
    public static int player1Score;
    public static int player2Score;
    public static int player1currentHealth;
    public static int player2currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        player2currentHealth = 100;
        player1currentHealth = 100;
    } 
    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        Player2.text = player2Score.ToString();
        Player1.text = player1Score.ToString();
        Player1Health.text = player1currentHealth.ToString();
        Player2Health.text = player2currentHealth.ToString();
    }
    public void startMenu()
    {
        SceneManager.LoadScene("Home Screen");
        player1Score = 0;
        player2Score = 0;
    }
    public void resetScore()
    {
        Player2.text = "0";
        Player1.text = "0";
        
    }
    


}
