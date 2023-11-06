using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            PlayerManager1.isGameOver = true;
            //AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
            Time.timeScale = 0;

        }
    }
}
