using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    [SerializeField] private Text LivesText = null;
    private int Score = 0;
    private int Lives = 3;
    private float CountDown = 1.5f;
    private bool CanReciveDamage;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
        CountDown = 1.5f;
        CanReciveDamage = true;
    }

    void Update()
    {
        DamageCountDown();
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Lives = 3;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
        LivesText.text = "LIVES : 3";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;
    }

    public void Damage(int value)
    {
        if(CanReciveDamage)
        {
            Lives -= value;
            LivesText.text = "LIVES : " + Lives;
            CanReciveDamage = false;
        }
       
        if(Lives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void DamageCountDown()
    {
        if(!CanReciveDamage)
        {
            if(CountDown <= 0)
            {
                CanReciveDamage = true;
                CountDown = 1.5f;
            }
            else
            {
                CountDown -= Time.deltaTime;
            }
        }
    }
}
