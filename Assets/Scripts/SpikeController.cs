using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip dieSound;
    public SoundEffectManager soundEffectManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundEffectManager.Play(dieSound);
            if (GameData.life > 1)
            {
                
                GameData.life--;
                if(GameData.currentLevel == 1)
                {
                    Destroy(GameObject.Find("Music"));
                    SceneManager.LoadScene("Level"+GameData.currentLevel);
                } else
                {
                    SceneManager.LoadScene("Level"+GameData.currentLevel);
                }

            } else if (GameData.life <= 1)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
       
    }
}
