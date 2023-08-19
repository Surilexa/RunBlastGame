using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public static bool LoseMenuOn = false;



    public GameObject LoseUI;
    public SceneLoader scene;

    private void Awake()
    {
        LoseUI.SetActive(false);

    }

    public void LoseGame()
    {

        LoseUI.SetActive(true);
        Time.timeScale = 0f;
        LoseMenuOn = true;

        //Debug.Log("End");

    }
    public void ResetGame()
    {
        SceneManager.LoadScene("Level01"); //Load scene called Game
        LoseUI.SetActive(false);
        Time.timeScale = 1f;
        LoseMenuOn = false;
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void MainMenu()
    {
        scene.LoadScene("MainMenu");
    }
}
