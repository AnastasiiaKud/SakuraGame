using System;
using DefaultNamespace;
using UnityEngine;
using TMPro;

public class CoinCheck : MonoBehaviour
{
    public TextMeshProUGUI scaleText;
    [SerializeField] private AudioSource audioCoin;

    private void Awake()
    {
        DataBaseManager.playerScore = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            DataBaseManager.playerScore += 100;

            if (scaleText != null)
                DisplayScale();
            audioCoin.Play();
        }
    }

    public void DisplayScale()
    {
        scaleText.text = DataBaseManager.playerScore.ToString();
    }
}