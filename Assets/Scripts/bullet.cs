using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform target;

    public float speed = 180f;

    private Vector3 dir;
    private float distanceThisFrame;

    private bool hasAttacked = false;
    public void Seek (Transform _target)
    {
        
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (!hasAttacked)
        {
            dir = target.position - transform.position;
            shot();
        }
        
        distanceThisFrame = speed * Time.deltaTime;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); 
    }
    void HitTarget()
    {
        Destroy(gameObject);
        ResetAttack();
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }
    public void shot()
    {
        hasAttacked = true;
    }



}

