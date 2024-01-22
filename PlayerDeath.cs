using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerMovement player;
    public GameObject playerGameObject;
    public GameObject deathPlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.deathState == true)
        {
            playerGameObject.SetActive(false);
            GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
            deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
            player.deathState = false;
            Invoke("ReloadLevel", 3);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
