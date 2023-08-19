using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] Text _currentFastestTime;
    [SerializeField] Text healAbilityCharge;
    public ScoreController score;

    public int _currentScore;
    public float _currentTime = Mathf.Infinity;

    private int healCounter = 0;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel(false);
        }

    }
    public void ExitLevel(bool win)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            //Debug.Log("New high score: " + _currentScore);
        }
        float fastestTime = PlayerPrefs.GetFloat("FastestTime");
        if (_currentTime < fastestTime && win == true)
        {
            PlayerPrefs.SetFloat("FastestTime", _currentTime);
        }

        SceneManager.LoadScene("MainMenu");
    }
    public void IncreaseScore(int value)
    {

        _currentScore += value;

        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }
    public void setTime(float value)
    {
        _currentTime = value;
    }
    public bool chargeHeal()
    {
        if(healCounter != 6)
        {
            healCounter++;
            healAbilityCharge.text = healCounter.ToString() + "/7";
        }
        else
        {
            healAbilityCharge.text = "7/7";
            return true;
        }
        return false;
    }
    public void castHeal()
    {
        healCounter = 0;
        healAbilityCharge.text = healCounter.ToString() + "/7";
    }

}
