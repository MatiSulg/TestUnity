using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 15f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    int count = 0;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); 
            
            foreach (GameObject enemy in enemys)
            {
                enemy.GetComponent<Enemy>().firedOn = true;
                enemy.GetComponent<Enemy>().targetSet = false;
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemys)
            {
                enemy.GetComponent<Enemy>().firedOn = false;
                enemy.GetComponent<Enemy>().targetSet = false;
            }
        }

        else if (Input.GetMouseButton(0))
        {
            if (count % 10 == 0)
            {
                Shoot();
            }
            count++;
        }
    }

    public void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
