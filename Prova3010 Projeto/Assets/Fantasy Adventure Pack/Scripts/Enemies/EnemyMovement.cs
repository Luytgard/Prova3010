using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    bool isFacingRight = true;
    float startingX;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * direction);
        
        FlipSprite();
        
        if (transform.position.x <= startingX - range || transform.position.x >= startingX + range)
        {
            direction *= -1;
        }
    }

    void FlipSprite()
    {
        if (isFacingRight && transform.position.x <= startingX - range || !isFacingRight && transform.position.x >= startingX + range)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;

        }
    }
}
