using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager1.numberOfCoins++;
            //PlayerPrefs.SetInt("NumberOfCoins", PlayerManager1.numberOfCoins);//Isso salva a quantidade de moedas, ativar nos scripts PlayerManager1 e Coins
            Destroy(gameObject);
        }
    }
}
