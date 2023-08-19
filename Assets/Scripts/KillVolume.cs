using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    public Player player;
    void OnCollisionEnter(Collider coll)
    {

        if (coll.tag == "Player")
        {
            player.TakeDamage(25);

        }
    }
}
