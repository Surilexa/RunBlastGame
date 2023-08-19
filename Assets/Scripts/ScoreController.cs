using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private float timeTaken = 0f;
    private int killCount = 0;
    private int headshotCount = 0;
    private int bodyshotCount = 0;
    private int armsDisabledCount = 0;
    private int totalshots = 0;
    private int score = 0;

    public Level01Controller level;

    public Player player;
    public AudioSource healing;

    public Text setTime;
    public Text setKills;
    public Text setHeadshots;
    public Text setBodyshots;
    public Text setArmDisabled;
    public Text setShotsTaken;
    private int totalScore;
    public Text setHeadshotP;
    public Text setTotalScore;

    private int counter = 0, healCounter = 0;
    private bool isAbility = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (isAbility == true)
                healAbility();
        }
    }
    public void KillCounter()
    {
        killCount++;
        isAbility = level.chargeHeal();
        //Debug.Log(killCount);
 
    }
    public int getKillCounter()
    {
        return killCount;
    }
    public void healAbility()
    {
        if (isAbility)
        {
            level.castHeal();
            isAbility = false;
        }
         player.TakeDamage(-25);

         player.ActiveDamage(false);
         healing.Play();
        
        
    }

    public void TimeTaken(float time)
    {
        timeTaken = time;
    }

    public void headshotCounter()
    {
        headshotCount++;
    }
    public void bodyshotCounter()
    {
        bodyshotCount++;
    }
    public void armsDisabled()
    {
        armsDisabledCount++;
    }
    public float headshotPercentage()
    {
        return (float)headshotCount / totalshots;
    }
    public void totalShotCounter()
    {
        totalshots++;
    }
    public void scoreCounter(int value)
    {
        score = value;
    }
    public void setScoreReport()
    {
        setTime.text = timeTaken.ToString();
        setKills.text = killCount.ToString();
        //Debug.Log("scoreReport " + killCount.ToString());

        setHeadshots.text = headshotCount.ToString();
        setBodyshots.text = bodyshotCount.ToString();
        setArmDisabled.text = armsDisabledCount.ToString();
        setShotsTaken.text = totalshots.ToString();
        setHeadshotP.text = ((float)headshotCount / (float)totalshots * 100).ToString() + "%";
    }
    public  void setScoreReportWin()
    {
        if (timeTaken <= 30f)
        {
            totalScore = score * 5;
            setTotalScore.text = score.ToString() + " x  5 = " + (score * 5).ToString();
            level.IncreaseScore(getTotalScore() - score);
        }
        else if (timeTaken <= 40f)
        {
            totalScore = score * 4;
            setTotalScore.text = score.ToString() + " x  4 = " + (score * 4).ToString();
            level.IncreaseScore(getTotalScore() - score);
        }
        else if (timeTaken <= 50f)
        {
            totalScore = score * 3;
            setTotalScore.text = score.ToString() + " x  3 = " + (score * 3).ToString();
            level.IncreaseScore(getTotalScore() - score);
        }
        else if (timeTaken <= 60f)
        {
            totalScore = score * 2;
            setTotalScore.text = score.ToString() + " x  2 = " + (score * 2).ToString();
            level.IncreaseScore(getTotalScore() - score);
        }
        else
        {
            totalScore = score;
            setTotalScore.text = score.ToString() + " x  1 = " + (score * 1).ToString();
        }
    }
    public int getTotalScore()
    {
        return totalScore;
    }
}
