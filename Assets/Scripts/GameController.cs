using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;

    public float currentScore = 0;
    [SerializeField] Text scoreAmount;

    private void Start()
    {
        currentScore = 0;
        UpdateScoreUi();
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            xPos = Random.Range(30, 35);
            zPos = Random.Range(-10, 10);
            Instantiate(enemy, new Vector3(xPos, (float)1.5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
        UpdateScoreUi();
    }

    private void UpdateScoreUi()
    {
        scoreAmount.text = currentScore.ToString("0");
    }
}

