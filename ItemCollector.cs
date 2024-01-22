using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coinCount = 0;

    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private AudioSource coinCollectSE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinCount++;
            coinText.text = "Coins: " + coinCount.ToString();
            coinCollectSE.Play();
        }
    }
}
