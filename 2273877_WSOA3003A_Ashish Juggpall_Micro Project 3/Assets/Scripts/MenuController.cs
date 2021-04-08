using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public static bool PausedGame = false;
    public GameObject PauseMenuUI;

    public GameObject Player;
    public GameObject Villain;
    public GameObject Enemy;

    public GameObject VillainHealthUI;
    public GameObject EnemyHealthUI;

    public bool IsPlayerTurn = true;
    public bool IsVillainTurn = false;

    public GameObject PlayerBattleUI;
    public GameObject PlayerHealthUI;
    public GameObject BattleWonUI;
    public GameObject BattleLossUI;

    public void Start()
    {

    }
    //PauseMenu button
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausedGame)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        PausedGame = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        PausedGame = true;
    }

    public void References()
    {
        SceneManager.LoadScene(3);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MidLevel()
    {
        SceneManager.LoadScene(2);
        BattleWonUI.SetActive(false);
        Villain.SetActive(true);
        Enemy.SetActive(false);
    }
    public void FinalLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
