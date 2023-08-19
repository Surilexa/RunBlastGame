using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioSource gunFire;
    public GameObject impactEffect;
    public Level01Controller level;
    public ScoreController score;


    private float nextTimetoFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }
       
    }
    void Shoot()
    {
        RaycastHit hit;

        muzzleFlash.Play();
        gunFire.Play();

        score.totalShotCounter();

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
          //  Debug.Log(hit.transform.name);

            Target enemy = hit.transform.GetComponent<Target>();

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Head"))
            {
                enemy.headDamage(damage);
                score.headshotCounter();
                level.IncreaseScore(60);
            }
            else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Body"))
            {
                enemy.bodyDamage(damage);
                score.bodyshotCounter();
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("leftArm"))
            {
                enemy.armLeftDamage(damage);
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("rightArm"))
            {
                enemy.armRightDamage(damage);
            }
                
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
        }    
    }
}
