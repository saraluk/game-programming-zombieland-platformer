﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        GameData.life = 3;
        GameData.currentLevel = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
