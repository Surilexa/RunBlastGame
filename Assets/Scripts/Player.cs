using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 25;

    public int currentHealth;

    public HeathBar healthBar;

    public Level01Controller level;

    public LoseMenu lose;
    public GameObject lose1;

    public Win winMenu;
    public GameObject WinMenu1;

    public ScoreController score;
    public Timer time;

    public SlowMotion timeManager;

    public bool isDead = false;

    
    //public float scoreMultiplier = 2f;

    public Image blood;


    void Start()
    {
        ActiveDamage(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(5);
        }
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                timeManager.doSlowmotion();
            }
        }
        
        //level.IncreaseScore((int)(scoreMultiplier * Time.deltaTime));
    }
    public void TakeDamage(int damage)
    {

        if(damage < 0)
        {
            currentHealth = 25;
        }
        else
        {
            currentHealth -= damage;
        }
        

        //Debug.Log(currentHealth);

        
        healthBar.sethealth(currentHealth);
        

        if(currentHealth <= 0)
        {
            killPlayer();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kill Volume")
        {
            killPlayer();
        }
        if(other.tag == "Bullet")
        {
            ActiveDamage(true);
            TakeDamage(5);
            level.IncreaseScore(-150);
        }
        if(other.tag == "Win")
        {
            isDead = true;
            ActiveDamage(false);
            score.TimeTaken(time.currentTime);
            //Debug.Log(time.currentTime);
            score.scoreCounter(level._currentScore);
           // Debug.Log(level._currentScore);
            score.setScoreReport();
            score.setScoreReportWin();
            level.setTime(time.currentTime);
            WinMenu1.SetActive(true);
            winMenu.WinGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    public void ActiveDamage(bool isBlood)
    {
        if (isBlood)
        {
            blood.enabled = true;
        }
        else
        {
            blood.enabled = false;
        }
    }
    public void setHealth(int value)
    {
        currentHealth = value;
    }
    public void killPlayer()
    {
        isDead = true;
        ActiveDamage(false);
        lose1.SetActive(true);
        lose.LoseGame();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
