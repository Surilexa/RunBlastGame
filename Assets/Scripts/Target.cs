using UnityEngine;

public class Target : MonoBehaviour
{

    [Header("Health Settings")]

    public float bodyHealth = 100f;
    public float headHealth = 100f;

    public float rightArm = 20f;
    public float leftArm = 20f;

    [Header("Controller")]
    public Level01Controller level;
    public Enemy bot;
    public ScoreController score;
    public Timer time;

    [Header("Audio Sources")]
    public AudioSource headshot;

    [Header("Particle Settings")]

    public ParticleSystem leftArmP;
    public ParticleSystem rightArmP;
    public ParticleSystem deathP;
    public ParticleSystem deathAfterP;

    public void armRightDamage(float amount)
    {

       // totalHealth -= (amount * 1.5f);
        rightArm -= amount;
        
        if (rightArm <= 0)
        {
            score.armsDisabled();
            rightArmP.Play();
            partDie();
            
        }
    }
    public void armLeftDamage(float amount)
    {

        //totalHealth -= (amount * 1.5f);
        leftArm -= amount;
        
        if(leftArm <= 0)
        {
            score.armsDisabled();
            bot.isArm();
            leftArmP.Play();
            partDie();
        }
    }
    public void bodyDamage(float amount)
    {
        bodyHealth -= (amount * 2f);
        if (bodyHealth <= 0)
        {
            Die();
        }
    }
    public void headDamage(float amount)
    {
        //Debug.Log("headshot");
        headshot.Play();
        headHealth -= (amount * 5f);
        if (headHealth <= 0)
        {
            Die();
        }
        
    }   

    void Die()
    {
        score.KillCounter();
        deathP.Play();
        deathAfterP.Play();
        Destroy(rightArmP);
        Destroy(leftArmP);
        level.IncreaseScore(100);
        Destroy(transform.parent.gameObject);
    }
    void partDie()
    {
        Destroy(gameObject);
    }
}
