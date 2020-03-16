using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text level;
    public Text lifeRemain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = GameData.currentLevel.ToString();
        lifeRemain.text = GameData.life.ToString();
    }
}
