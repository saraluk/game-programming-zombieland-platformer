using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    static float speed = 2;
    float speedX = speed;
    bool facingRight = true;
    public int minBound;
    public int maxBound;

    public AudioClip dieSound;
    public SoundEffectManager soundEffectManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.Translate(speedX * Time.deltaTime, 0,0);

        if(pos.x > maxBound)
        {
            speedX = -1*speed;
            if(facingRight) Flip();
        }
        if (pos.x < minBound)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundEffectManager.Play(dieSound);
            if (GameData.life > 1)
            {
                GameData.life--;
                SceneManager.LoadScene("Level"+GameData.currentLevel);

            } else if (GameData.life <= 1)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
       
    }

}
