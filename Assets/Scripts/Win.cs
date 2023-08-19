using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public static bool WinMenuOn = false;



    public GameObject WinUI;
    public SceneLoader scene;


    private void Awake()
    {
        WinUI.SetActive(false);

    }

    public void WinGame()
    {

        WinUI.SetActive(true);
        Time.timeScale = 0f;
        WinMenuOn = true;


        
       // Debug.Log("End");

    }
    public void ResetGame()
    {
        SceneManager.LoadScene("Level01"); //Load scene called Game
        WinUI.SetActive(false);
        Time.timeScale = 1f;
        WinMenuOn = false;
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
