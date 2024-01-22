using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    private AudioSource winSE;

    private bool levelComplete = false;


    // Start is called before the first frame update
    private void Start()
    {
        winSE = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplete)
        {
            winSE.Play();
            levelComplete = true;
            Invoke("WinLevel", 1f);
        }
    }

    private void WinLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
