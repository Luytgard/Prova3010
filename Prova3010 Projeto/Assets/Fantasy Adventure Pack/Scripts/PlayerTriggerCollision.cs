using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerHealthManager.health--;
            if (PlayerHealthManager.health <= 0)
            {
                //PlayerManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(8, 10);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(8, 10,false);
    }
}
