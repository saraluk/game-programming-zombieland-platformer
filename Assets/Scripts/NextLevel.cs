using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName;
    public AudioClip doorSound;

    public SoundEffectManager soundEffectManager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current Level in Start: " + GameData.currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        soundEffectManager.Play(doorSound);
        SceneManager.LoadScene(levelName);
        GameData.currentLevel++;
        Debug.Log("Current Level in onTrigger : " + GameData.currentLevel);
    }
}
