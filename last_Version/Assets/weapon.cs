using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public float damage = 21f;
    public float fireRate = 1f;
    public float force = 195f;
    public float range = 15f;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public GameObject hitEffect;

   
    public Camera _cam;
    private float nesxtFire = 0f;



    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time > nesxtFire)
        {
            nesxtFire = Time.time + 1f / fireRate;
        Shoot();
        }
    }


    void Shoot()
    {
        muzzleFlash.Play();
        
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            Debug.Log("Цель поражена");
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }

}
