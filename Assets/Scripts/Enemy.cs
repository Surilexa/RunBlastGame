using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]

    public float range = 15f;
    public Transform enemy;

    public float fireRate = 3f;
    public float fireCountdown = 0f;

    [Header("Backgorund Settings")]

    public AudioSource bulletSound;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string playerTag = "Player";
    public Transform target;

    public bool hasArm = true;
    private void Start()
    {
        InvokeRepeating("findTarget", 0f, 0.5f);
    }
    void findTarget()
    {
        GameObject player1 = null;
       // float shortestDistance = Mathf.Infinity;
        GameObject[] player = GameObject.FindGameObjectsWithTag(playerTag);

        foreach(GameObject user in player)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, user.transform.position);
           // Debug.Log(distanceToPlayer);
            if(distanceToPlayer < range)
            {
                player1 = user;
            }
            else
            {
                player1 = null;
            }
        }
        if (player1 != null)
        {
           // Debug.Log("Found within " + range);
            target = player1.transform;
            Vector3 dir = target.position - transform.position;

            Quaternion lookRotation = Quaternion.LookRotation(dir);

            Vector3 rotation = lookRotation.eulerAngles;

            enemy.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountdown <= 0f && hasArm == true)
            {
                ShootAtPlayer();
                //Debug.Log("no Arm stinky!");
                fireCountdown = fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }
    void Update()
    {

        if(target == null)
        {
            return;
        }
        findTarget();
    }

    void ShootAtPlayer()
    {
        bulletSound.Play();
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletObject.GetComponent<bullet>();

        if(bullet != null && hasArm == true)
        {
            
            bullet.Seek(target);
        }
        //Debug.Log("SHOOT!");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public void isArm()
    {
       // Debug.Log("no arm!");
        hasArm = false;
    }

}
