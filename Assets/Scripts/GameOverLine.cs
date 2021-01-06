using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        SceneManager.LoadScene("GameOver");
    }
}
