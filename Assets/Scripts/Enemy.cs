using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public GameController scoreValue;

    public float health = 50f;
    public float value = 15f;

    int rngNum;
    int countPossibleHideSpots = 0;
    public bool targetSet = false;
    public bool firedOn = false;
    string closestHidingSpotWallName;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        scoreValue = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (firedOn == false)
        {
            if (targetSet == false)
            {
                rngNum = Random.Range(1, 5);
                targetSet = true;
            }
            target = GameObject.Find("EnemyTarget/Target" + rngNum);
        }
        else if (firedOn == true)
        {
            float distancetoClosestHidingSpot = Mathf.Infinity;
            GameObject[] walls2 = GameObject.FindGameObjectsWithTag("Wall2");

            if (targetSet == false)
            {
                countPossibleHideSpots = 0;
                foreach (GameObject wall2 in walls2)
                {

                    if ((this.transform.position.x - wall2.transform.position.x) > 0)
                    {
                        countPossibleHideSpots++;
                        float distanceToHidingSpot = (wall2.transform.position - this.transform.position).sqrMagnitude;

                        if (distanceToHidingSpot < distancetoClosestHidingSpot)
                        {
                            distancetoClosestHidingSpot = distanceToHidingSpot;
                            closestHidingSpotWallName = wall2.name;
                        }
                    }
                }
                targetSet = true;
            }
            if (countPossibleHideSpots == 0)
            {
                firedOn = false;
            }
            target = GameObject.Find(closestHidingSpotWallName + "/HideSpot");
            
        }


        GoToTarget();
    }

    private void GoToTarget()
    {
        agent.SetDestination(target.transform.position);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            scoreValue.AddScore(value);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
