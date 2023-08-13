using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private bool isFinished = false;
    private AudioSource finishAudio;
    private void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isFinished) 
        {
            finishAudio.Play();
            isFinished = true;
            Invoke("CompleteLevel", 3f);    
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
