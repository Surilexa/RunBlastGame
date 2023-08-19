using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
   // [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;
    [SerializeField] Text _fastestTime;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        //load high score display
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        float fastestTime = PlayerPrefs.GetFloat("FastestTime");
        _fastestTime.text = fastestTime.ToString();
        //play starting song
        /*if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }*/

    }
    public void resetScore()
    {
        //Debug.LogError("reset");
        PlayerPrefs.SetInt("HighScore", 0);

        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();


        PlayerPrefs.SetFloat("FastestTime", Mathf.Infinity);

        float fastestTime = PlayerPrefs.GetFloat("FastestTime");
        _fastestTime.text = fastestTime.ToString();
    }
    
}

