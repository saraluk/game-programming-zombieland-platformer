using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkAroundController : MonoBehaviour
{
    static float speed = 2;
    float speedX = speed;
     bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.Translate(speedX * Time.deltaTime, 0,0);

        if(pos.x > 2.5)
        {
            speedX = -1*speed;
            if(facingRight) Flip();
        }
        if (pos.x < -1.5)
        {
            speedX = speed;
            if(facingRight == false) Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}
